namespace Husky.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NamedTypeTests
    {
        [TestMethod]
        public void CreateWithName()
        {
            var type = new NamedType("Foo");
            Assert.AreEqual("Foo", type.Name);
        }
    }
}
