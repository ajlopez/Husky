namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerType : IType
    {
        private static IntegerType instance = new IntegerType();

        private IntegerType()
        {
        }

        public static IntegerType Instance { get { return instance; } }
    }
}
