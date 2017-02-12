﻿namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using System.Globalization;

    public class Parser
    {
        private Lexer lexer;

        public Parser(string text)
        {
            this.lexer = new Lexer(text);
        }

        public IExpression ParseExpression()
        {
            var token = this.lexer.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Integer)
                return new IntegerExpression(int.Parse(token.Value));

            if (token.Type == TokenType.Real)
                return new DoubleExpression(double.Parse(token.Value, CultureInfo.InvariantCulture));

            if (token.Type == TokenType.String)
                return new StringExpression(token.Value);

            return null;
        }
    }
}
