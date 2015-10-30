﻿namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
        private static char[] operators = new char[] { '+', '-', '*' };
        private static char[] delimiters = new char[] { ',', '(', ')' };

        private string text;
        private int length;
        private int position;

        public Lexer(string text)
        {
            this.text = text;
            
            if (text == null)
                this.length = 0;
            else
                this.length = text.Length;

            this.position = 0;
        }

        public Token NextToken()
        {
            while (this.position < this.length && char.IsWhiteSpace(this.text[this.position]))
                this.position++;

            if (this.position >= this.length)
                return null;

            char ch = this.text[this.position++];

            if (operators.Contains(ch))
                return new Token(ch.ToString(), TokenType.Operator);

            if (delimiters.Contains(ch))
                return new Token(ch.ToString(), TokenType.Delimiter);

            if (char.IsDigit(ch))
                return this.NextInteger(ch);

            if (char.IsLetter(ch))
                return this.NextName(ch);

            throw new LexerException(string.Format("Unexpected '{0}'", ch));
        }

        private Token NextName(char ch)
        {
            string value = ch.ToString();

            while (this.position < this.length && char.IsLetterOrDigit(this.text[this.position]))
                value += this.text[this.position++];

            Token token = new Token(value, TokenType.Name);

            return token;
        }

        private Token NextInteger(char ch)
        {
            string value = ch.ToString();

            while (this.position < this.length && char.IsDigit(this.text[this.position]))
                value += this.text[this.position++];

            if (this.position < this.length && this.text[this.position] == '.')
                return this.NextReal(value);

            Token token = new Token(value, TokenType.Integer);

            return token;
        }

        private Token NextReal(string value)
        {
            value += '.';
            this.position++;

            while (this.position < this.length && char.IsDigit(this.text[this.position]))
                value += this.text[this.position++];

            Token token = new Token(value, TokenType.Real);

            return token;
        }
    }
}
