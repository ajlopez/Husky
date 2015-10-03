namespace Husky.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void CreateWithNameAndType()
        {
            var type = new NamedType("Foo");
            var cons = new Constructor("Bar", type);
            Assert.AreEqual("Bar", cons.Name);
            Assert.AreSame(type, cons.Type);
        }
    }
}
