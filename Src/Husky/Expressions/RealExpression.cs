namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
