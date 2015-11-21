namespace Husky.Tests.Declarations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Declarations;
    using Husky.Types;
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

        [TestMethod]
        public void Execute()
        {
            var ctx = new Context<IType>();
            var decl = new TypeDeclaration("Day");

            decl.Execute(ctx);

            var result = ctx.GetValue("Day");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NamedType));
            Assert.AreEqual("Day", ((NamedType)result).Name);
        }
    }
}
