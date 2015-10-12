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
        private Context<IExpression> expressionContext = new Context<IExpression>();
        private Context<IType> typeContext = new Context<IType>();

        public Machine()
        {
            this.typeContext.SetValue("Integer", IntegerType.Instance);
            this.typeContext.SetValue("Double", DoubleType.Instance);

            var tbool = new BaseType();

            this.typeContext.SetValue("Boolean", tbool);
            this.expressionContext.SetValue("False", new ValueExpression(tbool));
            this.expressionContext.SetValue("True", new ValueExpression(tbool));
        }

        public Context<IExpression> ExpressionContext { get { return this.expressionContext; } }

        public Context<IType> TypeContext { get { return this.typeContext; } }
    }
}
