namespace Husky.Tests.Expressions
{
    using System;
    using Husky.Expressions;
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConstructorExpressionTests
    {
        [TestMethod]
        public void CreateConstructor()
        {
            var cons = new ConstructorExpression(IntegerType.Instance);

            Assert.AreSame(IntegerType.Instance, cons.Type);
            Assert.AreSame(cons, cons.Reduce());
        }
    }
}
