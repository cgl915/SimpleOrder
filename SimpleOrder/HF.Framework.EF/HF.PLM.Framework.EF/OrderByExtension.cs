using System;
using System.Linq;
using System.Linq.Expressions;

namespace HF.PLM.Framework.EF
{
	public static class OrderByExtension
	{
		public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool isDescending) where T : class
		{
			Type typeFromHandle = typeof(T);
			ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, string.Empty);
			MemberExpression memberExpression = Expression.Property(parameterExpression, propertyName);
			LambdaExpression expression = Expression.Lambda(memberExpression, new ParameterExpression[]
			{
				parameterExpression
			});
			string methodName = isDescending ? "OrderByDescending" : "OrderBy";
			MethodCallExpression expression2 = Expression.Call(typeof(Queryable), methodName, new Type[]
			{
				typeFromHandle,
				memberExpression.Type
			}, new Expression[]
			{
				source.Expression,
				Expression.Quote(expression)
			});
			return source.Provider.CreateQuery<T>(expression2);
		}
	}
}
