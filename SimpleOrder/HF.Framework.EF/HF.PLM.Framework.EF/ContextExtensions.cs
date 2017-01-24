using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HF.PLM.Framework.EF
{
	public static class ContextExtensions
	{
		public static string GetTableName<T>(this DbContext context) where T : class
		{
			ObjectContext objectContext =((IObjectContextAdapter)context).ObjectContext;
			return objectContext.GetTableName<T>();
		}

		public static string GetTableName<T>(this ObjectContext context) where T : class
		{
			string input = context.CreateObjectSet<T>().ToTraceString();
			Regex regex = new Regex("FROM\\s*(?<table>\\S*)\\s*?.*");
			Match match = regex.Match(input);
			return match.Groups["table"].Value;
		}
	}
}
