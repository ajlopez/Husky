namespace Husky.Tests.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseTypeTests
    {
        [TestMethod]
        public void Match()
        {
            var type1 = new BaseType();
            var type2 = new BaseType();

            Assert.IsTrue(type1.Match(type1));
            Assert.IsFalse(type1.Match(null));
            Assert.IsFalse(type1.Match(type2));
        }
    }
}
