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
            Assert.AreSame(expr, expr.Reduce());
        }

        [TestMethod]
        public void MatchIntegerConstant()
        {
            var expr = new IntegerExpression(42);
            var expr1 = new IntegerExpression(42);
            var expr2 = new IntegerExpression(3);
            var expr3 = new DoubleExpression(1.2);

            Assert.IsTrue(expr.Match(expr, null));
            Assert.IsTrue(expr.Match(expr1, null));

            Assert.IsFalse(expr.Match(null, null));
            Assert.IsFalse(expr.Match(expr2, null));
            Assert.IsFalse(expr.Match(expr3, null));
        }

        [TestMethod]
        public void GetDoubleConstant()
        {
            var expr = new DoubleExpression(3.14159);

            Assert.AreEqual(3.14159, expr.Value);
            Assert.AreSame(DoubleType.Instance, expr.Type);
            Assert.AreSame(expr, expr.Reduce());
        }

        [TestMethod]
        public void MatchDoubleConstant()
        {
            var expr = new DoubleExpression(1.2);
            var expr1 = new DoubleExpression(1.2);
            var expr2 = new DoubleExpression(3.4);
            var expr3 = new IntegerExpression(42);

            Assert.IsTrue(expr.Match(expr, null));
            Assert.IsTrue(expr.Match(expr1, null));

            Assert.IsFalse(expr.Match(null, null));
            Assert.IsFalse(expr.Match(expr2, null));
            Assert.IsFalse(expr.Match(expr3, null));
        }

        [TestMethod]
        public void GetStringConstant()
        {
            var expr = new StringExpression("foo");

            Assert.AreEqual("foo", expr.Value);
            Assert.AreSame(StringType.Instance, expr.Type);
            Assert.AreSame(expr, expr.Reduce());
        }

        [TestMethod]
        public void MatchStringConstant()
        {
            var expr = new StringExpression("foo");
            var expr1 = new StringExpression("foo");
            var expr2 = new StringExpression("bar");
            var expr3 = new IntegerExpression(42);

            Assert.IsTrue(expr.Match(expr, null));
            Assert.IsTrue(expr.Match(expr1, null));

            Assert.IsFalse(expr.Match(null, null));
            Assert.IsFalse(expr.Match(expr2, null));
            Assert.IsFalse(expr.Match(expr3, null));
        }

        [TestMethod]
        public void EqualExpressions()
        {
            var expr1 = new IntegerExpression(1);
            var expr2 = new IntegerExpression(2);
            var expr3 = new IntegerExpression(1);
            var expr4 = new DoubleExpression(3.14159);
            var expr5 = new DoubleExpression(1.2);
            var expr6 = new DoubleExpression(3.14159);
            
            Assert.IsFalse(expr1.Equals(expr2));
            Assert.IsFalse(expr1.Equals(null));
            Assert.IsFalse(expr2.Equals(expr1));
            Assert.IsFalse(expr1.Equals(expr4));
            Assert.IsFalse(expr1.Equals(expr5));
            Assert.IsFalse(expr4.Equals(expr1));
            Assert.IsFalse(expr5.Equals(expr1));
            Assert.IsFalse(expr4.Equals(expr5));
            Assert.IsFalse(expr5.Equals(expr4));

            Assert.IsTrue(expr1.Equals(expr3));
            Assert.IsTrue(expr3.Equals(expr1));
            Assert.IsTrue(expr4.Equals(expr6));
            Assert.IsTrue(expr6.Equals(expr4));

            Assert.AreEqual(expr1.GetHashCode(), expr3.GetHashCode());
            Assert.AreEqual(expr4.GetHashCode(), expr6.GetHashCode());
        }
    }
}
