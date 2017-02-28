﻿namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum TokenType
    {
        Name = 1,
        Integer = 2,
        Real = 3,
        String = 4,
        Operator = 5,
        Delimiter = 6,
        NewLine = 7
    }
}
