namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
using Husky.Types;

    public class AddIntegersFunction : IFunction
    {
        private static IType type = new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance));

        public AddIntegersFunction()
        {
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new IntegerExpression(((IntegerExpression)exprs[0]).Value + ((IntegerExpression)exprs[1]).Value); 
        }

        public IType Type { get { return type; } }

        public IExpression Reduce()
        {
            return this;
        }
    }
}
