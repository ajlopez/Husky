namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class NameExpression : IExpression
    {
        private string name;
        private IType type;

        public NameExpression(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public IType Type { get { return this.type; } }

        public IExpression Reduce()
        {
            throw new NotImplementedException();
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            var result = ctx.GetValue(this.name);

            if (result != null)
                return result.Match(expr, ctx);

            if (result != null)
                return false;

            ctx.SetValue(this.name, expr);

            return true;
        }
    }
}
