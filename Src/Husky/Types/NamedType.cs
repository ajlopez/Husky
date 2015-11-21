namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NamedType : BaseType
    {
        private string name;

        public NamedType(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
