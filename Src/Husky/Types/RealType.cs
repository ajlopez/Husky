namespace Husky.Types
{
    public class RealType : IType
    {
        private static RealType instance = new RealType();

        private RealType()
        {
        }

        public static RealType Instance { get { return instance; } }

        public bool Match(IType type)
        {
            return this == type;
        }
    }
}
