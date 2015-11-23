namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
        private static string[] operators = new string[] { "+", "-", "*", "/", ":", "::", "->", "<-", "==", "/=", "<", ">", "<=", ">=" };
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
            this.SkipWhiteSpaces();

            if (this.position >= this.length)
                return null;

            char ch = this.text[this.position++];

            if (ch == '"')
                return this.NextString();

            if (!char.IsLetterOrDigit(ch))
            {
                string value = ch.ToString();

                if (this.position < this.length)
                {
                    string value2 = value + this.text[this.position].ToString();

                    if (operators.Contains(value2))
                    {
                        this.position++;
                        return new Token(value2, TokenType.Operator);
                    }
                }

                if (operators.Contains(value))
                    return new Token(value, TokenType.Operator);

                if (delimiters.Contains(ch))
                    return new Token(value, TokenType.Delimiter);
            }

            if (char.IsDigit(ch))
                return this.NextInteger(ch);

            if (char.IsLetter(ch))
                return this.NextName(ch);

            throw new LexerException(string.Format("Unexpected '{0}'", ch));
        }

        private Token NextString()
        {
            string value = string.Empty;

            while (this.position < this.length && this.text[this.position] != '"')
                value += this.text[this.position++];

            if (this.position < this.length)
                this.position++;
            else
                throw new LexerException("Unclosed string");

            Token token = new Token(value, TokenType.String);

            return token;
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

        private void SkipWhiteSpaces()
        {
            while (true)
            {
                while (this.position < this.length && char.IsWhiteSpace(this.text[this.position]))
                    this.position++;

                if (this.position < this.length - 1 && this.text[this.position] == '-' && this.text[this.position + 1] == '-')
                {
                    while (this.position < this.length && this.text[this.position] != '\n')
                        this.position++;

                    this.position++;
                }
                else if (this.position < this.length - 1 && this.text[this.position] == '{' && this.text[this.position + 1] == '-')
                {
                    while (this.position < this.length - 1 && (this.text[this.position] != '-' || this.text[this.position + 1] != '}'))
                        this.position++;

                    this.position += 2;
                }
                else
                    return;
            }
        }
    }
}
