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
        private ExecutionContext context;

        public Parser(string text, ExecutionContext context)
        {
            this.lexer = new Lexer(text);
            this.context = context;
        }

        public IExpression ParseExpression()
        {
            return this.ParseTerm();
        }

        private IExpression ParseTerm()
        {
            var token = this.lexer.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Integer)
                return new IntegerExpression(int.Parse(token.Value));

            if (token.Type == TokenType.Real)
                return new RealExpression(double.Parse(token.Value, CultureInfo.InvariantCulture));

            if (token.Type == TokenType.String)
                return new StringExpression(token.Value);

            if (token.Type == TokenType.Name)
            {
                string name = token.Value;

                IType type = this.context.GetValueType(name);

                if (type != null)
                    return new TypeExpression(type);

                return new NameExpression(token.Value);
            }

            return null;
        }
    }
}
