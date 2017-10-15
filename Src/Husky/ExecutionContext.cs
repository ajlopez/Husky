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

        public void DefineValue(string name, IType type)
        {
            if (valueTypes.ContainsKey(name))
                throw new InvalidOperationException(String.Format("Value '{0}' already defined", name));
            
            valueTypes[name] = type;
        }

        public IType GetValueType(string name)
        {
            if (!valueTypes.ContainsKey(name))
                return null;

            return valueTypes[name];
        }

        public void MapValue(String name, IExpression expr)
        {
        }

        public IExpression GetValue(String name)
        {
            return null;
        }

        public void DefineType(string name, IType type)
        {
        }

        public IType GetType(string name)
        {
            return null;
        }
    }
}
