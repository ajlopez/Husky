namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class ConstructorFunction : IFunction
    {
        private IType type;
        private IList<IType> types;

        public ConstructorFunction(IType type, IList<IType> types)
        {
            this.type = type;
            this.types = types;
        }

        public IType Type { get { return this.type; } }

        public IExpression Reduce()
        {
            return this; 
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new InstanceExpression(this, exprs);
        }
    }
}
