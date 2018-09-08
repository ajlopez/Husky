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
            Assert.IsFalse(RealType.Instance.Match(null));
            Assert.IsFalse(RealType.Instance.Match(IntegerType.Instance));
            Assert.IsFalse(RealType.Instance.Match(new MapType(IntegerType.Instance, RealType.Instance)));

            Assert.IsTrue(RealType.Instance.Match(RealType.Instance));
        }
    }
}
