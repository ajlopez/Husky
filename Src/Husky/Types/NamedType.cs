namespace Husky.Types
{
    public class NamedType : BaseType
    {
        private string name;

        public NamedType(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
