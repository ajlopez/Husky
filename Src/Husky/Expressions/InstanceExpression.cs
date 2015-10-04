namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Functions;
    using Husky.Types;

    public class InstanceExpression : IExpression
    {
        private ConstructorFunction consfn;
        private IList<IExpression> exprs;

        public InstanceExpression(ConstructorFunction consfn, IList<IExpression> exprs)
        {
            this.consfn = consfn;
            this.exprs = exprs;
        }

        public IType Type { get { return this.consfn.InstanceType; } }

        public IExpression Reduce()
        {
            return this;
        }
    }
}
