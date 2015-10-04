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

        [TestMethod]
        public void Match()
        {
            var type = new MapType(IntegerType.Instance, DoubleType.Instance);

            Assert.IsFalse(type.Match(null));
            Assert.IsFalse(type.Match(IntegerType.Instance));
            Assert.IsFalse(type.Match(DoubleType.Instance));

            Assert.IsFalse(type.Match(new MapType(DoubleType.Instance, DoubleType.Instance)));
            Assert.IsFalse(type.Match(new MapType(IntegerType.Instance, IntegerType.Instance)));

            Assert.IsTrue(type.Match(new MapType(IntegerType.Instance, DoubleType.Instance)));
        }
    }
}
