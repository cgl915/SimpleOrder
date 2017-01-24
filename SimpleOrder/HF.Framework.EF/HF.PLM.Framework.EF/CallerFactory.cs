using System;
using System.Collections;
using System.Reflection;
using HF.PLM.Framework.Commons;

namespace HF.PLM.Framework.EF
{
	public class CallerFactory<T>
	{
		private static Hashtable hashtable_0 = new Hashtable();

		private static object object_0 = new object();

		private static string string_0 = null;

		public static T Instance
		{
			get
			{
				string fullName = typeof(T).FullName;
				T t = (T)((object)CallerFactory<T>.hashtable_0[fullName]);
				if (t == null)
				{
					lock (CallerFactory<T>.object_0)
					{
						if (t == null)
						{
							t = CallerFactory<T>.smethod_0();
							if (t != null)
							{
								CallerFactory<T>.hashtable_0.Add(typeof(T).FullName, t);
							}
						}
					}
				}
				return t;
			}
		}

		private static T smethod_0()
		{
			T result = default(T);
			Assembly assembly = CallerFactory<T>.smethod_1();
			if (assembly != null)
			{
				Type[] types = assembly.GetTypes();
				for (int i = 0; i < types.Length; i++)
				{
					Type type = types[i];
					if (type != null && typeof(T).IsAssignableFrom(type) && !type.IsInterface && type.FullName.Contains(CallerFactory<T>.string_0))
					{
						result = (T)((object)Activator.CreateInstance(type));
						break;
					}
				}
			}
			return result;
		}

		private static Assembly smethod_1()
		{
			AppConfig appConfig = new AppConfig();
			string text = appConfig.AppConfigGet("CallerType");
			bool flag = !string.IsNullOrEmpty(text) && text.ToLower() == "wcf";
			string @namespace = typeof(T).Namespace;
			string str = @namespace.Substring(0, @namespace.LastIndexOf('.'));
			CallerFactory<T>.string_0 = (flag ? (str + ".ServiceCaller") : (str + ".WinformCaller"));
			string name = typeof(T).Assembly.GetName().Name;
			return Assembly.Load(name);
		}
	}
}
