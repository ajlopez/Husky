namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public abstract class ConstantExpression<T> : IExpression
    {
        private T value;

        public ConstantExpression(T value)
        {
            this.value = value;
        }

        public T Value { get { return this.value; } }

        public abstract IType Type { get; }
    }
}
