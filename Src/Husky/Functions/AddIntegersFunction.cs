namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;

    public class AddIntegersFunction
    {
        public AddIntegersFunction()
        {
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            return new IntegerExpression(((IntegerExpression)exprs[0]).Value + ((IntegerExpression)exprs[1]).Value); 
        }
    }
}
