using System;
using System.Linq.Expressions;

namespace HF.PLM.Framework.EF
{
	public class ParameterReplacer : ExpressionVisitor
	{
		private readonly ParameterExpression parameterExpression_0;

		private readonly Expression expression_0;

		private ParameterReplacer(ParameterExpression parameter, Expression replacement)
		{
			this.parameterExpression_0 = parameter;
			this.expression_0 = replacement;
		}

		public static Expression Replace(Expression expression, ParameterExpression parameter, Expression replacement)
		{
			return new ParameterReplacer(parameter, replacement).Visit(expression);
		}

		protected override Expression VisitParameter(ParameterExpression parameter)
		{
			Expression result;
			if (parameter == this.parameterExpression_0)
			{
				result = this.expression_0;
			}
			else
			{
				result = base.VisitParameter(parameter);
			}
			return result;
		}
	}
}
