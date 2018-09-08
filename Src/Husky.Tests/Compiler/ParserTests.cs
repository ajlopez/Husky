namespace Husky.Tests.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using Husky.Compiler;
    using Husky.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Husky.Types;

    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void NullTextAsNullExpression()
        {
            Parser parser = new Parser(null, null);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void EmptyStringAsNullExpression()
        {
            Parser parser = new Parser(string.Empty, null);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseIntegerAsIntegerExpression()
        {
            Parser parser = new Parser("42", null);

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(42, ((IntegerExpression)result).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseRealAsDoubleExpression()
        {
            Parser parser = new Parser("1.23", null);

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RealExpression));
            Assert.AreEqual(1.23, ((RealExpression)result).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseStringAsStringExpression()
        {
            Parser parser = new Parser("\"foo\"", null);

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StringExpression));
            Assert.AreEqual("foo", ((StringExpression)result).Value);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseNameAsNameExpression()
        {
            Parser parser = new Parser("foo", new ExecutionContext());

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NameExpression));
            Assert.AreEqual("foo", ((NameExpression)result).Name);

            Assert.IsNull(parser.ParseExpression());
        }

        [TestMethod]
        public void ParseNameAsTypeExpression()
        {
            ExecutionContext ctx = new ExecutionContext();
            ctx.DefineValue("Foo", IntegerType.Instance);

            Parser parser = new Parser("Foo", ctx);

            var result = parser.ParseExpression();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TypeExpression));
            Assert.AreEqual(IntegerType.Instance, ((TypeExpression)result).Type);

            Assert.IsNull(parser.ParseExpression());
        }
    }
}
