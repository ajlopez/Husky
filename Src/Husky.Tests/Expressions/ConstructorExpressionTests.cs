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
    public class ConstructorExpressionTests
    {
        [TestMethod]
        public void ReduceConstructorExpression()
        {
            var fn = new ConstructorFunction(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)));

            var expr = new ConstructorExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });

            Assert.AreSame(expr, expr.Reduce());
        }

        [TestMethod]
        public void Match()
        {
            var fn = new ConstructorFunction(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)));

            var expr = new ConstructorExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var expr2 = new ConstructorExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var expr3 = new ConstructorExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(3) });

            Assert.IsTrue(expr.Match(expr2, null));
            Assert.IsFalse(expr.Match(expr3, null));
        }
    }
}
