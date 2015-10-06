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
        private IType instancetype;
        private IList<IType> types;

        public ConstructorFunction(IType type, IList<IType> types)
        {
            this.instancetype = type;
            this.types = types;
            this.type = type;

            for (int k = types.Count; k > 0; k--)
                this.type = new MapType(types[k - 1], this.type);
        }

        public IType Type { get { return this.type; } }

        public IType InstanceType { get { return this.instancetype; } }

        public IExpression Reduce()
        {
            return this; 
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new InstanceExpression(this, exprs);
        }

        public bool HasMappers()
        {
            return true;
        }
    }
}
