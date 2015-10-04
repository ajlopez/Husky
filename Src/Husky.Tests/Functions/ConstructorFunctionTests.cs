namespace Husky.Tests.Functions
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Functions;
    using Husky.Types;

    [TestClass]
    public class ConstructorFunctionTests
    {
        [TestMethod]
        public void CreateConstructorFunction()
        {
            var consfn = new ConstructorFunction(IntegerType.Instance, new IType[] { IntegerType.Instance });

            Assert.IsTrue((new MapType(IntegerType.Instance, IntegerType.Instance)).Match(consfn.Type));
            Assert.AreSame(IntegerType.Instance, consfn.InstanceType);
            Assert.AreSame(consfn, consfn.Reduce());
        }
    }
}
