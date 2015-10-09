namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BaseType : IType
    {
        public bool Match(IType type)
        {
            return this.Equals(type);
        }
    }
}
