using Expressions;
using Expressions.Operators;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExpressionTests
{
    [TestFixture]
    public class SimpleExpressionTests
    {
        [Test]
        public void ReturnsLoneArgumentsValue()
        {
            var number = 1234.567;
            var tokens = new Token[] { new Argument(number) };

            CheckResult(tokens, number);
        }

        [Test]
        public void CalculatesSimpleSum()
        {
            var tokens = new Token[]
            {
                new Argument(4),
                new Argument(5),
                new SumOperator()
            };

            CheckResult(tokens, 9);
        }

        [Test]
        public void CalculatesSimpleDivision()
        {
            var tokens = new Token[]
            {
                new Argument(18.9),
                new Argument(3),
                new DivisionOperator()
            };

            CheckResult(tokens, 6.3);
        }

        [Test]
        public void ResolvesMultipleOperatorExpression()
        {
            var tokens = new Token[]
            {
                new Argument(47.5),
                new Argument(38.5),
                new SubtractOperator(),
                new Argument(2),
                new MultiplicationOperator()
            };

            CheckResult(tokens, 18);
        }

        private void CheckResult(IEnumerable<Token> tokens, double expectedResult)
        {
            var expression = new RpnExpression(tokens);
            Assert.AreEqual(expectedResult, expression.CalculateResult());
        }
    }
}
