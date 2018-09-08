namespace Husky.Expressions
{
    using Husky.Types;

    public class RealExpression : ConstantExpression<double>
    {
        public RealExpression(double value)
            : base(value)
        {
        }

        public override IType Type { get { return RealType.Instance; } }
    }
}
