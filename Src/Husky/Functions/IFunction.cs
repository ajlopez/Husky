namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;

    public interface IFunction : IExpression
    {
        IExpression Apply(IList<IExpression> exprs);

        bool HasMappers();
    }
}
