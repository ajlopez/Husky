﻿namespace Husky.Types
{
    public class StringType : IType
    {
        private static StringType instance = new StringType();

        private StringType()
        {
        }

        public static StringType Instance { get { return instance; } }

        public bool Match(IType type)
        {
            return this == type;
        }
    }
}
