namespace Husky.Tests.Functions
{
    using System;
    using Husky.Expressions;
    using Husky.Functions;
    using Husky.Types;
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
        public void Match()
        {
            Assert.IsTrue((new AddIntegersFunction()).Match(new AddIntegersFunction(), null));
            Assert.IsTrue((new SubtractIntegersFunction()).Match(new SubtractIntegersFunction(), null));
            Assert.IsFalse((new AddIntegersFunction()).Match(new SubtractIntegersFunction(), null));
            Assert.IsFalse((new SubtractIntegersFunction()).Match(new AddIntegersFunction(), null));

            Assert.IsTrue((new AddRealsFunction()).Match(new AddRealsFunction(), null));
        }

        [TestMethod]
        public void SubtractIntegers()
        {
            Assert.AreEqual(-1, Subtract(1, 2));
            Assert.AreEqual(3, Subtract(1, -2));
            Assert.AreEqual(42, Subtract(44, 2));
        }

        [TestMethod]
        public void AddIntegersFunctionMethods()
        {
            var fn = new AddIntegersFunction();

            Assert.AreSame(fn, fn.Reduce());
            Assert.AreEqual(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)), fn.Type);
        }

        [TestMethod]
        public void AddRealssFunctionMethods()
        {
            var fn = new AddRealsFunction();

            Assert.AreSame(fn, fn.Reduce());
            Assert.AreEqual(new MapType(RealType.Instance, new MapType(RealType.Instance, RealType.Instance)), fn.Type);
        }

        [TestMethod]
        public void SubtractIntegersFunctionMethods()
        {
            var fn = new SubtractIntegersFunction();

            Assert.AreSame(fn, fn.Reduce());
            Assert.AreEqual(new MapType(IntegerType.Instance, new MapType(IntegerType.Instance, IntegerType.Instance)), fn.Type);
        }

        [TestMethod]
        public void AddThreeIntegersUsingFunctionalExpressions()
        {
            IExpression fn = new AddIntegersFunction();

            IExpression expr = new FunctionalExpression(fn, new IExpression[] { new FunctionalExpression(fn, new IExpression[] { new IntegerExpression(1), new IntegerExpression(2) }), new IntegerExpression(3) });

            Assert.AreEqual(new IntegerExpression(6), expr.Reduce());
        }

        [TestMethod]
        public void AddThreeRealsUsingFunctionalExpressions()
        {
            IExpression fn = new AddRealsFunction();

            IExpression expr = new FunctionalExpression(fn, new IExpression[] { new FunctionalExpression(fn, new IExpression[] { new RealExpression(1), new RealExpression(2) }), new RealExpression(3) });

            Assert.AreEqual(new RealExpression(6), expr.Reduce());
        }

        [TestMethod]
        public void AddReals()
        {
            Assert.AreEqual(3.5, Add(1.2, 2.3));
            Assert.AreEqual(-1.0, Add(1.5, -2.5));
            Assert.AreEqual(42.0, Add(44.0, -2.0));
        }

        private static int Add(int x, int y) 
        {
            IExpression exprx = new IntegerExpression(x);
            IExpression expry = new IntegerExpression(y);

            IExpression expr = (new AddIntegersFunction()).Apply(new IExpression[] { exprx, expry });

            return ((IntegerExpression)expr).Value;
        }

        private static double Add(double x, double y)
        {
            IExpression exprx = new RealExpression(x);
            IExpression expry = new RealExpression(y);

            IExpression expr = (new AddRealsFunction()).Apply(new IExpression[] { exprx, expry });

            return ((RealExpression)expr).Value;
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
