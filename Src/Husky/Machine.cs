namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Machine
    {
        private Context context = new Context();

        public Context Context { get { return this.context; } }
    }
}
