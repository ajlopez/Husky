namespace Husky.Tests.Expressions
{
    using System;
    using Husky.Expressions;
    using Husky.Functions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArithmeticFunctionTests
    {
        [TestMethod]
        public void AddIntegers()
        {
            Assert.AreEqual(3, Add(1, 2));
            Assert.AreEqual(-1, Add(1, -2));
            Assert.AreEqual(42, Add(44, -2));
        }

        private static int Add(int x, int y) 
        {
            IExpression exprx = new IntegerExpression(x);
            IExpression expry = new IntegerExpression(y);

            IExpression expr = (new AddIntegersFunction()).Apply(new IExpression[] { exprx, expry });

            return ((IntegerExpression)expr).Value;
        }
    }
}
