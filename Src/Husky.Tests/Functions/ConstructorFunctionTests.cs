namespace Husky.Tests.Functions
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Functions;
    using Husky.Types;
    using Husky.Expressions;

    [TestClass]
    public class ConstructorFunctionTests
    {
        [TestMethod]
        public void CreateConstructorFunction()
        {
            var consfn = new ConstructorFunction(IntegerType.Instance, new IType[] { IntegerType.Instance });

            Assert.IsTrue((new MapType(IntegerType.Instance, IntegerType.Instance)).Match(consfn.Type));
            Assert.AreSame(IntegerType.Instance, consfn.InstanceType);
            Assert.AreSame(consfn, consfn.Reduce());
        }

        [TestMethod]
        public void ApplyConstructorFunction()
        {
            var consfn = new ConstructorFunction(IntegerType.Instance, new IType[] { IntegerType.Instance });

            var result = consfn.Apply(new IExpression[] { new IntegerExpression(3) });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(InstanceExpression));

            var iexpr = (InstanceExpression)result;

            Assert.AreSame(consfn.InstanceType, iexpr.Type);
            Assert.AreSame(iexpr, iexpr.Reduce());
        }
    }
}
