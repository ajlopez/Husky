namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class Machine
    {
        private ExecutionContext context = new ExecutionContext();

        public Machine()
        {
            this.context.DefineType("Integer", IntegerType.Instance);
            this.context.DefineType("Double", RealType.Instance);
            this.context.DefineType("Boolean", BooleanType.Instance);

            this.context.DefineValue("False", BooleanType.Instance);
            this.context.MapValue("False", new BooleanExpression(false));

            this.context.DefineValue("True", BooleanType.Instance);
            this.context.MapValue("True", new BooleanExpression(true));
        }

        public ExecutionContext Context { get { return this.context; } }
    }
}
