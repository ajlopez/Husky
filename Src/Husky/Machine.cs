namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Language;
    using Husky.Types;

    public class Machine
    {
        private Context context = new Context();

        public Machine()
        {
            this.context.SetValue("Integer", IntegerType.Instance);
        }

        public Context Context { get { return this.context; } }
    }
}
