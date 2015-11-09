namespace Husky.Tests.Declarations
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Declarations;

    [TestClass]
    public class TypeDeclarationTests
    {
        [TestMethod]
        public void CreateWithName()
        {
            var decl = new TypeDeclaration("Day");

            Assert.AreEqual("Day", decl.Name);
        }
    }
}
