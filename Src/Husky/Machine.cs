namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Language;

    public class Machine
    {
        private Context context = new Context();

        public Machine()
        {
            this.context.SetValue("Integer", new NamedType("Integer"));
        }

        public Context Context { get { return this.context; } }
    }
}
