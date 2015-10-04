namespace Husky.Tests.Types
{
    using System;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MapTypeTests
    {
        [TestMethod]
        public void CreateMapTypeIntegerToInteger()
        {
            var type = new MapType(IntegerType.Instance, IntegerType.Instance);

            Assert.AreSame(IntegerType.Instance, type.FromType);
            Assert.AreSame(IntegerType.Instance, type.ToType);
        }
    }
}
