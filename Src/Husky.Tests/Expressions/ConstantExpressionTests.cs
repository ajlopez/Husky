namespace Husky.Tests.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConstantExpressionTests
    {
        [TestMethod]
        public void GetIntegerConstant()
        {
            var expr = new IntegerExpression(42);

            Assert.AreEqual(42, expr.Value);
            Assert.AreSame(IntegerType.Instance, expr.Type);
        }

        [TestMethod]
        public void GetDoubleConstant()
        {
            var expr = new DoubleExpression(3.14159);

            Assert.AreEqual(3.14159, expr.Value);
            Assert.AreSame(DoubleType.Instance, expr.Type);
        }
    }
}
