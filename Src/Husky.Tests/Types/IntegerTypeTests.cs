﻿namespace Husky.Tests.Types
{
    using System;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntegerTypeTests
    {
        [TestMethod]
        public void Match()
        {
            Assert.IsFalse(IntegerType.Instance.Match(null));
            Assert.IsFalse(IntegerType.Instance.Match(RealType.Instance));
            Assert.IsFalse(IntegerType.Instance.Match(new MapType(IntegerType.Instance, RealType.Instance)));

            Assert.IsTrue(IntegerType.Instance.Match(IntegerType.Instance));
        }
    }
}
