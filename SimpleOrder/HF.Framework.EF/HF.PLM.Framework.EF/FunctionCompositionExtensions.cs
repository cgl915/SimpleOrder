using System;
using System.Linq.Expressions;

namespace HF.PLM.Framework.EF
{
	public static class FunctionCompositionExtensions
	{
		public static Expression<Func<TX, TY>> Compose<TX, TY, TZ>(this Expression<Func<TZ, TY>> outer, Expression<Func<TX, TZ>> inner)
		{
			return Expression.Lambda<Func<TX, TY>>(ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body), new ParameterExpression[]
			{
				inner.Parameters[0]
			});
		}
	}
}
