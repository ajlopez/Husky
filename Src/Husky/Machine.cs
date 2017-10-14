namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class Machine
    {
        private Context<ValueExpression> expressionContext = new Context<ValueExpression>();
        private Context<IType> typeContext = new Context<IType>();

        public Machine()
        {
            this.typeContext.SetValue("Integer", IntegerType.Instance);
            this.typeContext.SetValue("Double", DoubleType.Instance);

            this.typeContext.SetValue("Boolean", BooleanType.Instance);

            var falsevalue = new ValueExpression(BooleanType.Instance);
            falsevalue.MapTo(new BooleanExpression(false));
            this.expressionContext.SetValue("False", falsevalue);

            var truevalue = new ValueExpression(BooleanType.Instance);
            truevalue.MapTo(new BooleanExpression(true));
            this.expressionContext.SetValue("True", truevalue);
        }

        public Context<ValueExpression> ExpressionContext { get { return this.expressionContext; } }

        public Context<IType> TypeContext { get { return this.typeContext; } }
    }
}
