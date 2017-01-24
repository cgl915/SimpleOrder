using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HF.PLM.Framework.EF
{
	public abstract class BaseContext : DbContext
	{
        [CompilerGenerated]
        private Assembly assembly_0;
        protected static ConnectionStringSettings defaultConnectStr = smethod_0();
        [CompilerGenerated]
        private static Func<Type, bool> func_0;
        [CompilerGenerated]
        private static Func<Type, bool> func_1;

        public BaseContext(Assembly assembly)
            : base(string.Format("name={0}", defaultConnectStr.Name))
        {
            this.assembly = assembly;
        }

        private string method_0(string string_0)
        {
            string str = "";
            string str3 = string_0;
            switch (str3)
            {
                case null:
                    return str;

                case "Oracle.ManagedDataAccess.Client":
                    return ".Oracle";

                case "MySql.Data.MySqlClient":
                    return ".MySql";
            }
            if (!(str3 == "System.Data.SQLite"))
            {
                if (str3 == "System.Data.SqlClient")
                {
                    str = ".SqlServer";
                }
                return str;
            }
            return ".SQLite";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string mapSuffix = this.method_0(defaultConnectStr.ProviderName);
            if (func_0 == null)
            {
                func_0 = new Func<Type, bool>(BaseContext.smethod_1);
            }
            if (func_1 == null)
            {
                func_1 = new Func<Type, bool>(BaseContext.smethod_2);
            }
            foreach (Type type in (from type in this.assembly.GetTypes().Where<Type>(func_0)
                                   where type.Namespace.EndsWith(mapSuffix, StringComparison.OrdinalIgnoreCase)
                                   select type).Where<Type>(func_1))
            {
                object obj2 = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add((dynamic)obj2);
            }
            base.OnModelCreating(modelBuilder);
        }

		private static ConnectionStringSettings smethod_0()
		{
			string text = ConfigurationManager.AppSettings["DefaultConnectionName"];
			if (string.IsNullOrEmpty(text))
			{
				BaseContext.defaultConnectStr = ConfigurationManager.ConnectionStrings[0];
			}
			else
			{
				foreach (ConnectionStringSettings connectionStringSettings in ConfigurationManager.ConnectionStrings)
				{
					if (connectionStringSettings.Name.Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						BaseContext.defaultConnectStr = connectionStringSettings;
						break;
					}
				}
			}
			if (BaseContext.defaultConnectStr == null)
			{
				throw new ArgumentException("没有找到DefaultConnection的配置项连接字符串：" + text);
			}
			return BaseContext.defaultConnectStr;
		}

        [CompilerGenerated]
        private static bool smethod_1(Type type_0)
        {
            return !string.IsNullOrEmpty(type_0.Namespace);
        }

        [CompilerGenerated]
        private static bool smethod_2(Type type_0)
        {
            return (((type_0.BaseType != null) && type_0.BaseType.IsGenericType) && (type_0.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));
        }

        protected Assembly assembly
        {
            [CompilerGenerated]
            get
            {
                return this.assembly_0;
            }
            [CompilerGenerated]
            set
            {
                this.assembly_0 = value;
            }
        }
	}
}
