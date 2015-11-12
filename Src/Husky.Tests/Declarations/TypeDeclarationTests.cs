namespace Husky.Tests.Declarations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Declarations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
