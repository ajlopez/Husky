namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class ConstructorFunction : IExpression
    {
        private MapType type;

        public ConstructorFunction(MapType type)
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
