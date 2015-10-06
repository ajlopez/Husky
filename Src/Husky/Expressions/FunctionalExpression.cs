namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Functions;
    using Husky.Types;

    public class FunctionalExpression : IExpression
    {
        private IExpression head;
        private IList<IExpression> args;
        private IType type;

        public FunctionalExpression(IExpression head, IList<IExpression> args) 
        {
            this.head = head;
            this.args = args;

            this.type = head.Type;

            for (int k = 0; k < args.Count; k++)
                this.type = ((MapType)this.type).ToType;
        }

        public IType Type { get { return this.type; } }

        public IExpression Reduce()
        {
            IFunction fn = (IFunction)this.head.Reduce();

            if (!fn.HasMappers())
                return this;

            return ((IFunction)this.head.Reduce()).Apply(this.args);
        }
    }
}
