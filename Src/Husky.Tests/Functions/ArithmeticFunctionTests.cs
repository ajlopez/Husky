namespace Husky.Tests.Functions
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

        [TestMethod]
        public void SubtractIntegers()
        {
            Assert.AreEqual(-1, Subtract(1, 2));
            Assert.AreEqual(3, Subtract(1, -2));
            Assert.AreEqual(42, Subtract(44, 2));
        }

        [TestMethod]
        public void AddThreeIntegersUsingFunctionalExpressions()
        {
            IExpression fn = new AddIntegersFunction();

            IExpression expr = new FunctionalExpression(fn, new IExpression[] { new FunctionalExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) }), new IntegerExpression(3) });

            Assert.AreEqual(new IntegerExpression(6), expr.Reduce());
        }

        private static int Add(int x, int y) 
        {
            IExpression exprx = new IntegerExpression(x);
            IExpression expry = new IntegerExpression(y);

            IExpression expr = (new AddIntegersFunction()).Apply(new IExpression[] { exprx, expry });

            return ((IntegerExpression)expr).Value;
        }

        private static int Subtract(int x, int y)
        {
            IExpression exprx = new IntegerExpression(x);
            IExpression expry = new IntegerExpression(y);

            IExpression expr = (new SubtractIntegersFunction()).Apply(new IExpression[] { exprx, expry });

            return ((IntegerExpression)expr).Value;
        }
    }
}
