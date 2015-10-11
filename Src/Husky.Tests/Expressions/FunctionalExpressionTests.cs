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
    public class FunctionalExpressionTests
    {
        [TestMethod]
        public void AddIntegersFunctionalExpression()
        {
            var expr = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });

            Assert.AreEqual(new IntegerExpression(3), expr.Reduce());
            Assert.AreSame(IntegerType.Instance, expr.Type);
        }

        [TestMethod]
        public void MatchWithFunctionalExpression()
        {
            var expr = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var expr1 = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var expr2 = new FunctionalExpression(new SubtractIntegersFunction(), new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });
            var expr3 = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new IntegerExpression(2), new IntegerExpression(3) });

            Assert.IsTrue(expr.Match(expr, null));
            Assert.IsTrue(expr.Match(expr1, null));
            Assert.IsFalse(expr.Match(expr2, null));
            Assert.IsFalse(expr.Match(expr3, null));
        }

        [TestMethod]
        public void FunctionalExpressionWithFunctionWithoutMappers()
        {
            IFunction fn = new Function(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)));

            var expr = new FunctionalExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });

            Assert.AreSame(expr, expr.Reduce());
        }
    }
}
