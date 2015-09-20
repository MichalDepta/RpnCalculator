using Expressions;
using Expressions.Operators;
using NUnit.Framework;
using System;

namespace ExpressionTests
{
    [TestFixture]
    public class InvalidExpressionTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void ThrowsIfTooManyTokensInExpression()
        {
            var tokens = new Token[]
            {
                new Argument(4.5),
                new Argument(7),
                new SumOperator(),
                new Argument(-1)
            };

            var expression = new RpnExpression(tokens);
            var result = expression.CalculateResult();
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException))]
        public void ThrowsWhenTooFewArgumentsForOperator()
        {
            var tokens = new Token[]
            {
                new Argument(-3.7),
                new SumOperator()
            };

            var expression = new RpnExpression(tokens);
            var result = expression.CalculateResult();
        }
    }
}
