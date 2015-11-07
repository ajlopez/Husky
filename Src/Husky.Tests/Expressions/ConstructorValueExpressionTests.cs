namespace Husky.Tests.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Husky.Functions;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConstructorValueExpressionTests
    {
        [TestMethod]
        public void CreateWithType()
        {
            var vexpr = new ConstructorValueExpression(IntegerType.Instance);

            Assert.AreSame(IntegerType.Instance, vexpr.Type);
        }

        [TestMethod]
        public void Reduce()
        {
            var vexpr = new ConstructorValueExpression(IntegerType.Instance);

            Assert.AreSame(vexpr, vexpr.Reduce());
        }

        [TestMethod]
        public void Match()
        {
            var vexpr = new ConstructorValueExpression(IntegerType.Instance);
            var vexpr2 = new ConstructorValueExpression(IntegerType.Instance);
            var vexpr3 = new ConstructorValueExpression(DoubleType.Instance);

            Assert.IsTrue(vexpr.Equals(vexpr));
            Assert.IsFalse(vexpr.Equals(vexpr2));
            Assert.IsFalse(vexpr.Equals(vexpr3));
        }
    }
}

