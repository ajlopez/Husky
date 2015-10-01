namespace Husky.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContextTests
    {
        [TestMethod]
        public void GetUndefinedValueAsNull()
        {
            var ctx = new Context();

            Assert.IsNull(ctx.GetValue("foo"));
        }

        [TestMethod]
        public void SetAndGetValue()
        {
            var ctx = new Context();

            ctx.SetValue("foo", 42);

            Assert.AreEqual(42, ctx.GetValue("foo"));
        }
    }
}
