namespace Husky.Tests.Compiler
{
    using System;
    using Husky.Compiler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void GetNullTokenFromNullText()
        {
            Lexer lexer = new Lexer(null);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNullTokenFromEmptyText()
        {
            Lexer lexer = new Lexer(string.Empty);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetInteger()
        {
            Lexer lexer = new Lexer("42");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("42", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void SkipCommentUpToNewLine()
        {
            Lexer lexer = new Lexer("-- a comment\n");

            var token = lexer.NextToken();

            Assert.AreEqual(TokenType.NewLine, token.Type);
            Assert.AreEqual("\n", token.Value);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void SkipMultiLineComment()
        {
            Lexer lexer = new Lexer("{- a comment\nin many lines -}");

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetReal()
        {
            Lexer lexer = new Lexer("1.23");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("1.23", token.Value);
            Assert.AreEqual(TokenType.Real, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetString()
        {
            Lexer lexer = new Lexer("\"foo\"");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.String, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetUnclosedString()
        {
            Lexer lexer = new Lexer("\"foo");

            try
            {
                lexer.NextToken();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(LexerException));
                Assert.AreEqual("Unclosed string", ex.Message);
            }
        }

        [TestMethod]
        public void GetName()
        {
            Lexer lexer = new Lexer("foo");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNameWithDigits()
        {
            Lexer lexer = new Lexer("foo42");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo42", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetTwoNames()
        {
            Lexer lexer = new Lexer("foo bar");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("bar", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNameAndOperator()
        {
            Lexer lexer = new Lexer("foo+");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetBackquotedNameOperator()
        {
            Lexer lexer = new Lexer("`mod`");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("mod", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetPlusAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("+");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetMinusAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("-");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("-", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetAsteriskAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("*");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("*", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetSlashAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("/");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("/", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetSingleColonAsOperator()
        {
            Lexer lexer = new Lexer(":");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual(":", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetLambdaOperator()
        {
            Lexer lexer = new Lexer("\\");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\\", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetRangeOperator()
        {
            Lexer lexer = new Lexer("..");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("..", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetIndexingOperator()
        {
            Lexer lexer = new Lexer("!!");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("!!", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetDoubleColonAsOperator()
        {
            Lexer lexer = new Lexer("::");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("::", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetComparisonOperators()
        {
            Lexer lexer = new Lexer("< > <= >= == /=");

            foreach (var value in new string[] { "<", ">", "<=", ">=", "==", "/=" })
            {
                var token = lexer.NextToken();

                Assert.IsNotNull(token);
                Assert.AreEqual(value, token.Value);
                Assert.AreEqual(TokenType.Operator, token.Type);
            }

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetArrowsAsOperators()
        {
            Lexer lexer = new Lexer("-> <-");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("->", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("<-", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetPlusPlusAsOperator()
        {
            Lexer lexer = new Lexer("++");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("++", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCommaAsDelimiter()
        {
            Lexer lexer = new Lexer(",");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual(",", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNewLine()
        {
            Lexer lexer = new Lexer("\n");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\n", token.Value);
            Assert.AreEqual(TokenType.NewLine, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetTwoNewLines()
        {
            Lexer lexer = new Lexer("\n\n");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\n", token.Value);
            Assert.AreEqual(TokenType.NewLine, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\n", token.Value);
            Assert.AreEqual(TokenType.NewLine, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCarriageReturnNewLine()
        {
            Lexer lexer = new Lexer("\r\n");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\r\n", token.Value);
            Assert.AreEqual(TokenType.NewLine, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCarriageReturn()
        {
            Lexer lexer = new Lexer("\r");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("\r", token.Value);
            Assert.AreEqual(TokenType.NewLine, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetParensAsDelimiters()
        {
            Lexer lexer = new Lexer("()");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("(", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual(")", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNameInParens()
        {
            Lexer lexer = new Lexer("(Foo)");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("(", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("Foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual(")", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetSquareBracketsAsDelimiters()
        {
            Lexer lexer = new Lexer("[]");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("[", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("]", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void UnexpectedChar()
        {
            var lexer = new Lexer("@");

            try
            {
                lexer.NextToken();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(LexerException));
                Assert.AreEqual("Unexpected '@'", ex.Message);
            }
        }
    }
}

