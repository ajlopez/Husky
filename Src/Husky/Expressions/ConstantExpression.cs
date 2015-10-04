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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is ConstantExpression<T>))
                return false;

            return ((ConstantExpression<T>)obj).Value.Equals(this.Value);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        } 
    }
}
