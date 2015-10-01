namespace Husky.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
    }
}
