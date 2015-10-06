namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class SubtractIntegersFunction : IFunction
    {
        private static IType type = new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance));

        public SubtractIntegersFunction()
        {
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new IntegerExpression(((IntegerExpression)(exprs[0].Reduce())).Value - ((IntegerExpression)(exprs[1].Reduce())).Value); 
        }

        public IType Type { get { return type; } }

        public IExpression Reduce()
        {
            return this;
        }

        public bool HasMappers()
        {
            return true;
        }
    }
}
