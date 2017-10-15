namespace Husky.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Types;

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
    }
}
