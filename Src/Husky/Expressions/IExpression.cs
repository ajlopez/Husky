namespace Husky.Expressions
{
    using System;
    using Husky.Types;

    public interface IExpression
    {
        IType Type { get; }

        IExpression Reduce();

        bool Match(IExpression expr, Context<IExpression> ctx);
    }
}
