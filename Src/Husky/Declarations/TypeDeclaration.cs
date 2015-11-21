namespace Husky.Declarations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using Husky.Types;

    public class TypeDeclaration
    {
        private string name;

        public TypeDeclaration(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public void Execute(Context<IType> context)
        {
            context.SetValue(this.name, new NamedType(this.name));
        }
    }
}
