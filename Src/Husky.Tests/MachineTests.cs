namespace Husky.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Language;
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
        public void InitialTypes()
        {
            Machine machine = new Machine();

            object value = machine.Context.GetValue("Integer");

            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(NamedType));
            Assert.AreEqual("Integer", ((NamedType)value).Name);
        }
    }
}
