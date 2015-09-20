using Expressions;
using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests
{
    [TestFixture]
    public class ExpressionRepresentationTests
    {
        [Test]
        public void DisplaysReadableExpressionRepresentation()
        {
            var tokens = new Token[]
            {
                new Argument(89),
                new Argument(3.5),
                new SumOperator()
            };

            var expression = new RpnExpression(tokens);

            Assert.AreEqual("89 3.5 +", expression.ToString());
        }
    }
}
