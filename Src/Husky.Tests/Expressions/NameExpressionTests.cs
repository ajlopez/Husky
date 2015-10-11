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

        [TestMethod]
        public void MatchUnboundNameExpression()
        {
            var expr = new NameExpression("a");
            var ctx = new Context();
            var cexpr = new IntegerExpression(42);

            Assert.IsTrue(expr.Match(cexpr, ctx));

            Assert.AreSame(cexpr, ctx.GetValue("a"));
        }

        [TestMethod]
        public void MatchBoundNameExpression()
        {
            var expr = new NameExpression("a");
            var ctx = new Context();
            ctx.SetValue("a", new IntegerExpression(42));

            Assert.IsTrue(expr.Match(new IntegerExpression(42), ctx));
            Assert.IsFalse(expr.Match(new IntegerExpression(1), ctx));
        }
    }
}
