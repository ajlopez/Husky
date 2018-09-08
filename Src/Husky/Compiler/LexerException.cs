﻿namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [Serializable]
    public class LexerException : Exception
    {
        public LexerException(string message)
            : base(message)
        {
        }
    }
}
