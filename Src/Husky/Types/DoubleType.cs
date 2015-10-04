namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DoubleType : IType
    {
        private static DoubleType instance = new DoubleType();

        private DoubleType()
        {
        }

        public static DoubleType Instance { get { return instance; } }

        public bool Match(IType type)
        {
            return this == type;
        }
    }
}
