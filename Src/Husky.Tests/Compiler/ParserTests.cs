namespace Husky.Tests.Compiler
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Compiler;
    using System.Linq.Expressions;
    using Husky.Expressions;

    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void NullTextAsNullExpression()
        {
            Parser parser = new Parser(null);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void EmptyStringAsNullExpression()
        {
            Parser parser = new Parser(string.Empty);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseIntegerAsIntegerExpression()
        {
            Parser parser = new Parser("42");

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(42, ((IntegerExpression)result).Value);

            Assert.IsNull(parser.ParseExpression());
        }
    }
}
