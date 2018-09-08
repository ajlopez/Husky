namespace Husky.Expressions
{
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

        public IExpression Reduce()
        {
            return this;
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            if (expr == null)
                return false;

            if (!expr.GetType().Equals(this.GetType()))
                return false;

            return ((ConstantExpression<T>)expr).value.Equals(this.value);
        }
    }
}
