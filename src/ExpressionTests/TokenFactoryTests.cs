using System;
using Expressions;
using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests
{
    [TestFixture]
    public class TokenFactoryTests
    {
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void RecognizesOperators(string operatorString)
        {
            var isToken = TokenFactory.IsValidTokenString(operatorString);

            Assert.IsTrue(isToken);
        }

        [TestCase("+", typeof (SumOperator))]
        [TestCase("-", typeof (SubtractOperator))]
        [TestCase("*", typeof (MultiplicationOperator))]
        [TestCase("/", typeof (DivisionOperator))]
        public void ParsesOperators(string operatorString, Type expectedTokenType)
        {
            var result = TokenFactory.CreateToken(operatorString);

            Assert.IsInstanceOf(expectedTokenType, result);
        }

        [TestCase("5")]
        [TestCase("5.087")]
        [TestCase("-92.45")]
        public void RecognizesNumbers(string numberString)
        {
            var isToken = TokenFactory.IsValidTokenString(numberString);

            Assert.IsTrue(isToken);
        }

        [TestCase("34", 34)]
        [TestCase("710.1", 710.1)]
        [TestCase("-2.5", -2.5)]
        public void ParsesNumbers(string numberString, double expectedValue)
        {
            var result = TokenFactory.CreateToken(numberString);

            Assert.IsInstanceOf<Argument>(result);
            Assert.AreEqual(((Argument)result).Value, expectedValue);
        }

        [TestCase("abc")]
        [TestCase("+-")]
        [TestCase("12t1")]
        [TestCase("3-")]
        public void RecognizesInvalidTokens(string invalidToken)
        {
            var isToken = TokenFactory.IsValidTokenString(invalidToken);

            Assert.IsFalse(isToken);
        }

        [TestCase("abc")]
        [TestCase("+-")]
        [TestCase("12t1")]
        [TestCase("3-")]
        [ExpectedException(ExpectedException = typeof (ArgumentException))]
        public void ThrowsIfTryingToCreateTokenFromInvalidString(string invalidToken)
        {
            TokenFactory.CreateToken(invalidToken);
        }
    }
}