namespace Husky.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MapType : IType
    {
        private IType fromtype;
        private IType totype;

        public MapType(IType fromtype, IType totype)
        {
            this.fromtype = fromtype;
            this.totype = totype;
        }

        public IType FromType { get { return this.fromtype; } }

        public IType ToType { get { return this.totype; } }

        public bool Match(IType type)
        {
            if (type == null)
                return false;

            if (type is MapType)
                return this.fromtype.Match(((MapType)type).FromType) && this.totype.Match(((MapType)type).ToType);

            return false;
        }
    }
}
