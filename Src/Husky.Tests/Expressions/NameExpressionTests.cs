namespace Husky.Tests.Expressions
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Expressions;

    [TestClass]
    public class NameExpressionTests
    {
        [TestMethod]
        public void CreateNameExpression()
        {
            var expr = new NameExpression("a");

            Assert.AreEqual("a", expr.Name);
            Assert.IsNull(expr.Type);
        }
    }
}
