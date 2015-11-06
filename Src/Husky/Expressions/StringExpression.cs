namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class StringExpression : ConstantExpression<string>
    {
        public StringExpression(string value)
            : base(value)
        {
        }

        public override IType Type { get { return StringType.Instance; } }
    }
}
