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
        public void FunctionalExpressionWithFunctionWithoutMappers()
        {
            IFunction fn = new Function(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)));

            var expr = new FunctionalExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) });

            Assert.AreSame(expr, expr.Reduce());
        }
    }
}
