namespace Husky.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class Function
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

        public IExpression Apply(IExpression expr)
        {
            foreach (var mapper in this.mappers)
                if (mapper.Match(expr))
                    return mapper.To;

            return null;
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

            public IExpression From { get { return this.from; } }

            public IExpression To { get { return this.to; } }

            public bool Match(IExpression expr)
            {
                return this.from.Equals(expr);
            }
        }
    }
}
