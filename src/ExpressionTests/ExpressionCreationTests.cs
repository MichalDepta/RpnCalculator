using Expressions;
using Expressions.Operators;
using NUnit.Framework;
using System;

namespace ExpressionTests
{
    [TestFixture]
    public class ExpressionCreationTests
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void ThrowsIfTokensNull()
        {
            var expression = new RpnExpression(null);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void ThrowsIfTokensEmpty()
        {
            var expression = new RpnExpression(new Token[] { });
        }

        [Test]
        public void CreatesExpressionWithOneToken()
        {
            var expression = new RpnExpression(new Token[] { new Argument(5) });

            Assert.IsNotNull(expression);
        }

        [Test]
        public void CreatesExpressionWithManyTokens()
        {
            var expression = new RpnExpression(new Token[] { new Argument(1), new Argument(-8.4), new SumOperator() });
        }
    }
}
