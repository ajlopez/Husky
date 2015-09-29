namespace Husky.Tests.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NameExpressionTests
    {
        [TestMethod]
        public void GetUndefinedValueAsNull()
        {
            var ctx = new Context();
            var expr = new NameExpression("foo");

            Assert.AreEqual("foo", expr.Name);
            Assert.IsNull(expr.Evaluate(ctx));
        }

        [TestMethod]
        public void GetValue()
        {
            var ctx = new Context();
            ctx.SetValue("foo", 42);

            var expr = new NameExpression("foo");

            Assert.AreEqual("foo", expr.Name);
            Assert.AreEqual(42, expr.Evaluate(ctx));
        }
    }
}
