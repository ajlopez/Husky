namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class AddRealsFunction : IFunction
    {
        private static IType type = new MapType(RealType.Instance, new MapType(RealType.Instance, RealType.Instance));

        public AddRealsFunction()
        {
        }

        public IType Type { get { return type; } }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new RealExpression(((RealExpression)exprs[0].Reduce()).Value + ((RealExpression)exprs[1].Reduce()).Value); 
        }

        public IExpression Reduce()
        {
            return this;
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            return expr != null && expr is AddRealsFunction;
        }
    }
}
