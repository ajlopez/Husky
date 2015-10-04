namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class IntegerExpression : ConstantExpression<int>
    {
        public IntegerExpression(int value)
            : base(value)
        {
        }

        public override IType Type { get { return IntegerType.Instance; } }

        public IExpression Reduce()
        {
            return this;
        }
    }
}
