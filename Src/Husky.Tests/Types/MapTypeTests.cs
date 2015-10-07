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
        public void Equality()
        {
            var type1 = new MapType(IntegerType.Instance, IntegerType.Instance);
            var type2 = new MapType(IntegerType.Instance, DoubleType.Instance);
            var type3 = new MapType(IntegerType.Instance, IntegerType.Instance);

            Assert.IsFalse(type1.Equals(null));
            Assert.IsFalse(type1.Equals(42));
            Assert.IsFalse(type1.Equals("foo"));

            Assert.IsFalse(type1.Equals(type2));
            Assert.IsFalse(type2.Equals(type1));

            Assert.IsTrue(type1.Equals(type1));
            Assert.IsTrue(type1.Equals(type3));
            Assert.IsTrue(type3.Equals(type1));
            Assert.AreEqual(type1.GetHashCode(), type3.GetHashCode());
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
