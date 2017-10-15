namespace Husky.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Types;
    using Husky.Expressions;

    [TestClass]
    public class ExecutionContextTests
    {
        [TestMethod]
        public void GetUndefinedValueType()
        {
            ExecutionContext context = new ExecutionContext();

            var result = context.GetValueType("Foo");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetAndGetValueValueType()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineValue("Foo", IntegerType.Instance);
            var result = context.GetValueType("Foo");

            Assert.IsNotNull(result);
            Assert.AreSame(IntegerType.Instance, result);
        }

        [TestMethod]
        public void CannotDefineValueTypeTwice()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineValue("Foo", IntegerType.Instance);

            try
            {
                context.DefineValue("Foo", IntegerType.Instance);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Value 'Foo' already defined", ex.Message);
            }
        }

        [TestMethod]
        public void GetUndefinedValue()
        {
            ExecutionContext context = new ExecutionContext();

            var result = context.GetValue("Foo");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void CannoetMapValueWithoutType()
        {
            ExecutionContext context = new ExecutionContext();

            try
            {
                context.MapValue("a", new IntegerExpression(42));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Value 'a' has no type yet", ex.Message);
            }
        }

        [TestMethod]
        public void MapAndGetValue()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineValue("a", IntegerType.Instance);
            context.MapValue("a", new IntegerExpression(42));
            var result = context.GetValue("Foo");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void MapValueToWrongTypeExpression()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineValue("a", IntegerType.Instance);

            try
            {
                context.MapValue("a", new StringExpression("foo"));
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Invalid type for 'a' value", ex.Message);
            }
        }

        [TestMethod]
        public void GetUndefinedType()
        {
            ExecutionContext context = new ExecutionContext();

            Assert.IsNull(context.GetType("Foo"));
        }

        [TestMethod]
        public void DefineAndGetType()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineType("Int", IntegerType.Instance);
            Assert.AreSame(IntegerType.Instance, context.GetType("Int"));
        }

        [TestMethod]
        public void CannotDefineTypeTwice()
        {
            ExecutionContext context = new ExecutionContext();

            context.DefineType("Int", IntegerType.Instance);

            try
            {
                context.DefineType("Int", IntegerType.Instance);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Type 'Int' already defined", ex.Message);
            }
        }
    }
}
