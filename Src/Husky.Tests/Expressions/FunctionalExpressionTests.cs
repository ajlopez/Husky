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
        public void MatchVariableInFunctionalExpression()
        {
            var one = new IntegerExpression(1);
            var two = new IntegerExpression(2);
            var expr = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { new NameExpression("a"), new NameExpression("b") });
            var expr1 = new FunctionalExpression(new AddIntegersFunction(), new IExpression[] { one, two });

            Context<IExpression> ctx = new Context<IExpression>();

            Assert.IsTrue(expr.Match(expr1, ctx));

            Assert.AreSame(one, ctx.GetValue("a"));
            Assert.AreSame(two, ctx.GetValue("b"));
        }
    }
}
