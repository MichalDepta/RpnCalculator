using Expressions;
using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests.OperatorTests
{
    [TestFixture]
    public class MultiplicationTests
    {
        private MultiplicationOperator _multiplication = new MultiplicationOperator();

        [Test]
        [TestCase(4, 11, 44)]
        [TestCase(1.04, 3, 3.12)]
        [TestCase(-92, 0.5, -46)]
        public void CalculatesMultiplication(double arg1, double arg2, double expectedResult)
        {
            var result = _multiplication.CalculateResult(new Argument(arg1), new Argument(arg2));
            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}
