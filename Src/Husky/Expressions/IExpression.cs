namespace Husky.Expressions
{
    using System;

    public interface IExpression
    {
        object Evaluate(Husky.Context ctx);
    }
}
