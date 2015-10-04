namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class Function : IFunction
    {
        private MapType type;
        private IList<Mapper> mappers = new List<Mapper>();

        public Function(MapType type)
        {
            this.type = type;
        }

        public void Map(IExpression from, IExpression to)
        {
            this.mappers.Add(new Mapper(from, to));
        }

        public IType Type { get { return this.type; } }

        public IExpression Apply(IExpression expr)
        {
            foreach (var mapper in this.mappers)
                if (mapper.Match(expr))
                    return mapper.To;

            return null;
        }

        public IExpression Apply(IList<IExpression> exprs)
        {
            IExpression result = this;

            foreach (var expr in exprs)
                result = ((Function)result).Apply(expr);

            return result;
        }

        public IExpression Reduce()
        {
            return this;
        }

        private class Mapper
        {
            private IExpression from;
            private IExpression to;

            public Mapper(IExpression from, IExpression to)
            {
                this.from = from;
                this.to = to;
            }

            public IExpression To { get { return this.to; } }

            public bool Match(IExpression expr)
            {
                return this.from.Equals(expr);
            }
        }
    }
}
