namespace Husky.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NamedType
    {
        private string name;

        public NamedType(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
