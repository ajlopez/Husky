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
            var type = new MapType(IntegerType.Instance, IntegerType.Instance);
            var func = new Function(type);

            Assert.AreSame(func, func.Reduce());
            Assert.AreSame(type, func.Type);

            func.Map(new IntegerExpression(1), new IntegerExpression(2));

            Assert.AreEqual(new IntegerExpression(2), func.Apply(new IntegerExpression(1)));
        }

        [TestMethod]
        public void MapInvalidFromExpression()
        {
            var type = new MapType(IntegerType.Instance, IntegerType.Instance);
            var func = new Function(type);

            try
            {
                func.Map(new RealExpression(1.2), new IntegerExpression(2));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Non compatible type", ex.Message);
            }
        }

        [TestMethod]
        public void MapInvalidToExpression()
        {
            var type = new MapType(IntegerType.Instance, IntegerType.Instance);
            var func = new Function(type);

            try
            {
                func.Map(new IntegerExpression(1), new RealExpression(1.2));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Non compatible type", ex.Message);
            }
        }

        [TestMethod]
        public void MatchFunction()
        {
            var type = new MapType(IntegerType.Instance, IntegerType.Instance);
            var func = new Function(type);
            var func2 = new Function(type);

            Assert.IsTrue(func.Match(func, null));
            Assert.IsFalse(func.Match(null, null));
            Assert.IsFalse(func.Match(func2, null));
        }

        [TestMethod]
        public void ApplyExpressions()
        {
            var func = new Function(new MapType(IntegerType.Instance, IntegerType.Instance));

            func.Map(new IntegerExpression(1), new IntegerExpression(2));

            Assert.AreEqual(new IntegerExpression(2), func.Apply(new IExpression[] { new IntegerExpression(1) }));
        }
    }
}
