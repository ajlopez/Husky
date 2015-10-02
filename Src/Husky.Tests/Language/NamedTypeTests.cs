namespace Husky.Tests.Language
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Language;

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
