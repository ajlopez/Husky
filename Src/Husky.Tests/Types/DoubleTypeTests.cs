namespace Husky.Tests.Types
{
    using System;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DoubleTypeTests
    {
        [TestMethod]
        public void Match()
        {
            Assert.IsFalse(DoubleType.Instance.Match(null));
            Assert.IsFalse(DoubleType.Instance.Match(IntegerType.Instance));
            Assert.IsFalse(DoubleType.Instance.Match(new MapType(IntegerType.Instance, DoubleType.Instance)));

            Assert.IsTrue(DoubleType.Instance.Match(DoubleType.Instance));
        }
    }
}
