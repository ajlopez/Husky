namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class ConstructorValueExpression : IExpression
    {
        private IType type;

        public ConstructorValueExpression(IType type)
        {
            this.type = type;
        }

        public IType Type { get { return this.type; } }

        public IExpression Reduce()
        {
            return this;
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            return this.Equals(expr);
        }
    }
}
