namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class ConstructorExpression : IExpression
    {
        private IType type;

        public ConstructorExpression(IType type)
        {
            this.type = type;
        }

        public IType Type { get { return this.type; } }

        public IExpression Reduce()
        {
            return this;
        }
    }
}
