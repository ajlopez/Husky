﻿namespace Husky.Tests.Types
{
    using System;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringTypeTests
    {
        [TestMethod]
        public void Match()
        {
            Assert.IsFalse(StringType.Instance.Match(null));
            Assert.IsFalse(StringType.Instance.Match(RealType.Instance));
            Assert.IsFalse(StringType.Instance.Match(new MapType(StringType.Instance, RealType.Instance)));

            Assert.IsTrue(StringType.Instance.Match(StringType.Instance));
        }
    }
}
