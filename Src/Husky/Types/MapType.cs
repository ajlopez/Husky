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
    }
}
