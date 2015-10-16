namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
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
            while (position < length && char.IsWhiteSpace(this.text[position]))
                position++;

            if (position >= length)
                return null;

            string value = this.text[position++].ToString();

            while (position < length && !char.IsWhiteSpace(this.text[position]))
                value += this.text[position++];

            Token token = new Token(value, TokenType.Name);

            return token;
        }
    }
}
