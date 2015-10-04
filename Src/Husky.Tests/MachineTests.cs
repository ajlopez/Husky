namespace Husky.Tests
{
    using Husky.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void HasContext()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine.Context);
        }

        [TestMethod]
        public void HasIntegerType()
        {
            Machine machine = new Machine();

            object value = machine.Context.GetValue("Integer");

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(IntegerType));
            Assert.AreSame(IntegerType.Instance, value);
        }

        [TestMethod]
        public void HasDoubleType()
        {
            Machine machine = new Machine();

            object value = machine.Context.GetValue("Double");

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(DoubleType));
            Assert.AreSame(DoubleType.Instance, value);
        }
    }
}
