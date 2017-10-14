namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class BooleanExpression : ConstantExpression<bool>
    {
        public BooleanExpression(bool value)
            : base(value)
        {
        }

        public override IType Type { get { return BooleanType.Instance; } }
    }
}
