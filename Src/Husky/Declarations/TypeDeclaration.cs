namespace Husky.Declarations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TypeDeclaration
    {
        private string name;

        public TypeDeclaration(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
