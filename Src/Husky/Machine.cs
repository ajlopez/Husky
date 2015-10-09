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
        private Context context = new Context();

        public Machine()
        {
            this.context.SetValue("Integer", IntegerType.Instance);
            this.context.SetValue("Double", DoubleType.Instance);

            var tbool = new BaseType();

            this.context.SetValue("Boolean", tbool);
            this.context.SetValue("False", new ValueExpression(tbool));
            this.context.SetValue("True", new ValueExpression(tbool));
        }

        public Context Context { get { return this.context; } }
    }
}
