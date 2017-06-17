namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class Parser
    {
        private Lexer lexer;
        private Context<IType> typeContext;

        public Parser(string text, Context<IType> typeContext)
        {
            this.lexer = new Lexer(text);
            this.typeContext = typeContext;
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

            if (token.Type == TokenType.Name)
            {
                string name = token.Value;

                IType type = this.typeContext.GetValue(name);

                if (type != null)
                    return new TypeExpression(type);

                return new NameExpression(token.Value);
            }

            return null;
        }
    }
}
