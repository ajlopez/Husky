namespace Husky
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Context<T>
    {
        private Dictionary<string, T> values = new Dictionary<string, T>();

        public void SetValue(string name, T value)
        {
            this.values[name] = value;
        }

        public T GetValue(string name)
        {
            if (this.values.ContainsKey(name))
                return this.values[name];

            return default(T);
        }
    }
}
