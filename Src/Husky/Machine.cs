namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class Machine
    {
        private Context context = new Context();

        public Machine()
        {
            this.context.SetValue("Integer", IntegerType.Instance);
            this.context.SetValue("Double", DoubleType.Instance);
        }

        public Context Context { get { return this.context; } }
    }
}
