namespace Husky.Tests.Functions
{
    using System;
    using Husky.Expressions;
    using Husky.Functions;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void ApplyExpression()
        {
            var func = new Function(new MapType(IntegerType.Instance, IntegerType.Instance));

            func.Map(new IntegerExpression(1), new IntegerExpression(2));

            Assert.AreEqual(new IntegerExpression(2), func.Apply(new IntegerExpression(1)));
        }
    }
}
