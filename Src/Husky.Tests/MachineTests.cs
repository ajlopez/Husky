namespace Husky.Tests
{
    using Husky.Expressions;
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

            object value = machine.Context.GetType("Integer");

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(IntegerType));
            Assert.AreSame(IntegerType.Instance, value);
        }

        [TestMethod]
        public void HasDoubleType()
        {
            Machine machine = new Machine();

            object value = machine.Context.GetType("Double");

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(DoubleType));
            Assert.AreSame(DoubleType.Instance, value);
        }

        [TestMethod]
        public void HasBooleanTypeAndValues()
        {
            Machine machine = new Machine();

            var tbool = machine.Context.GetType("Boolean");

            Assert.IsNotNull(tbool);

            var vtrue = machine.Context.GetValue("True");

            Assert.IsNotNull(vtrue);
            Assert.AreSame(tbool, vtrue.Type);
            Assert.IsInstanceOfType(vtrue.Reduce(), typeof(BooleanExpression));
            Assert.AreEqual(true, ((BooleanExpression)vtrue.Reduce()).Value);

            var vfalse = machine.Context.GetValue("False");

            Assert.IsNotNull(vfalse);
            Assert.AreSame(tbool, vfalse.Type);
            Assert.IsInstanceOfType(vfalse.Reduce(), typeof(BooleanExpression));
            Assert.AreEqual(false, ((BooleanExpression)vfalse.Reduce()).Value);
        }
    }
}
