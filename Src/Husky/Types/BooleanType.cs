namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BooleanType : IType
    {
        private static BooleanType instance = new BooleanType();

        private BooleanType()
        {
        }

        public static BooleanType Instance { get { return instance; } }

        public bool Match(IType type)
        {
            return this == type;
        }
    }
}
