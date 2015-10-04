namespace Husky.Expressions
{
    using System;
    using Husky.Types;

    public interface IExpression
    {
        IType Type { get; }
    }
}
