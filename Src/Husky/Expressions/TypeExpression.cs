namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class TypeExpression : ConstantExpression<IType>
    {
        public TypeExpression(IType value)
            : base(value)
        {
        }

        public override IType Type { get { return this.Value; } }
    }
}
