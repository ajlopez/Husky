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
    public class ValueExpressionTests
    {
        [TestMethod]
        public void CreateWithType()
        {
            var vexpr = new ValueExpression(IntegerType.Instance);

            Assert.AreSame(IntegerType.Instance, vexpr.Type);
            Assert.IsNull(vexpr.Expression);
        }

        [TestMethod]
        public void MatchUndefinedValue()
        {
            var vexpr = new ValueExpression(IntegerType.Instance);

            Assert.IsTrue(vexpr.Match(vexpr, null));
        }

        [TestMethod]
        public void MatchDefinedValue()
        {
            var vexpr = new ValueExpression(IntegerType.Instance);

            vexpr.MapTo(new IntegerExpression(42));

            Assert.IsTrue(vexpr.Match(new IntegerExpression(42), null));
            Assert.IsFalse(vexpr.Match(new IntegerExpression(1), null));
        }

        [TestMethod]
        public void MapToExpression()
        {
            var expr = new IntegerExpression(42);
            var vexpr = new ValueExpression(IntegerType.Instance);

            vexpr.MapTo(expr);
            Assert.AreSame(expr, vexpr.Expression);
        }

        [TestMethod]
        public void Reduce()
        {
            var expr = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var vexpr = new ValueExpression(IntegerType.Instance);

            vexpr.MapTo(expr);

            var result = vexpr.Reduce();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(3, ((IntegerExpression)result).Value);
        }

        [TestMethod]
        public void ReduceTwice()
        {
            var expr = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var vexpr = new ValueExpression(IntegerType.Instance);

            vexpr.MapTo(expr);

            vexpr.Reduce();
            var result = vexpr.Reduce();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(3, ((IntegerExpression)result).Value);
        }

        [TestMethod]
        public void ReduceToItselfItNoMap()
        {
            var vexpr = new ValueExpression(IntegerType.Instance);

            var result = vexpr.Reduce();

            Assert.IsNotNull(result);
            Assert.AreSame(result, vexpr);
        }

        [TestMethod]
        public void InvalidOperationIfMapToNonCompatibleType()
        {
            var expr = new DoubleExpression(3.14159);
            var vexpr = new ValueExpression(IntegerType.Instance);

            try
            {
                vexpr.MapTo(expr);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Non compatible type", ex.Message);
            }
        }
    }
}

