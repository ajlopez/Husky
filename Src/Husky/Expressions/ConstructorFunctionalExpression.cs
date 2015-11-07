namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Functions;
    using Husky.Types;

    public class ConstructorFunctionalExpression : IExpression
    {
        private ConstructorFunction head;
        private IList<IExpression> args;
        private IType type;

        public ConstructorFunctionalExpression(ConstructorFunction head, IList<IExpression> args) 
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
            return this;
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            if (expr == null)
                return false;

            if (!(expr is ConstructorFunctionalExpression))
                return false;

            var fexpr = (ConstructorFunctionalExpression)expr;

            if (this.args.Count != fexpr.args.Count)
                return false;

            if (!this.head.Match(fexpr.head, ctx))
                return false;

            for (int k = 0; k < this.args.Count; k++)
                if (!this.args[k].Match(fexpr.args[k], ctx))
                    return false;

            return true;
        }
    }
}
