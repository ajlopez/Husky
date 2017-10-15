namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;

    public class ExecutionContext
    {
        private Dictionary<string, IType> valueTypes = new Dictionary<string, IType>();
        private Dictionary<string, IExpression> values = new Dictionary<string, IExpression>();
        private Dictionary<string, IType> types = new Dictionary<string, IType>();

        public void DefineValue(string name, IType type)
        {
            if (this.valueTypes.ContainsKey(name))
                throw new InvalidOperationException(String.Format("Value '{0}' already defined", name));
            
            this.valueTypes[name] = type;
        }

        public IType GetValueType(string name)
        {
            if (!this.valueTypes.ContainsKey(name))
                return null;

            return this.valueTypes[name];
        }

        public void MapValue(String name, IExpression expr)
        {
            if (!this.valueTypes.ContainsKey(name))
                throw new InvalidOperationException(String.Format("Value '{0}' has no type yet", name));

            var expected = this.valueTypes[name];

            if (!expr.Type.Match(expected))
                throw new InvalidOperationException(String.Format("Invalid type for '{0}' value", name));
            
            this.values[name] = expr;
        }

        public IExpression GetValue(String name)
        {
            if (!this.values.ContainsKey(name))
                return null;

            return this.values[name];
        }

        public void DefineType(string name, IType type)
        {
            if (this.types.ContainsKey(name))
                throw new InvalidOperationException(String.Format("Type '{0}' already defined", name));

            this.types[name] = type;
        }

        public IType GetType(string name)
        {
            if (!this.types.ContainsKey(name))
                return null;

            return this.types[name];
        }
    }
}
