namespace Husky.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Constructor
    {
        private NamedType type;
        private string name;

        public Constructor(string name, NamedType type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get { return this.name; } }

        public NamedType Type { get { return this.type; } }
    }
}
