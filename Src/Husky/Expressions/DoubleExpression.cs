namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class DoubleExpression : ConstantExpression<double>
    {
        public DoubleExpression(double value)
            : base(value)
        {
        }

        public override IType Type { get { return DoubleType.Instance; } }

        public IExpression Reduce()
        {
            return this;
        }
    }
}
