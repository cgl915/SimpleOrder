using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HF.PLM.Framework.EF
{
	public class ParameterRebinder : ExpressionVisitor
	{
		private readonly Dictionary<ParameterExpression, ParameterExpression> dictionary_0;

		public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
		{
			this.dictionary_0 = (map ?? new Dictionary<ParameterExpression, ParameterExpression>());
		}

		public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
		{
			return new ParameterRebinder(map).Visit(exp);
		}

		protected override Expression VisitParameter(ParameterExpression p)
		{
			ParameterExpression parameterExpression;
			if (this.dictionary_0.TryGetValue(p, out parameterExpression))
			{
				p = parameterExpression;
			}
			return base.VisitParameter(p);
		}
	}
}
