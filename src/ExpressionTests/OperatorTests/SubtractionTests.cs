using Expressions;
using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests.OperatorTests
{
    [TestFixture]
    public class SubtractionTests
    {
        private SubtractOperator _subtraction = new SubtractOperator();

        [Test]
        [TestCase(10, 3, 7)]
        [TestCase(-5.5, 2, -7.5)]
        [TestCase(4, -2.34, 6.34)]
        public void CalculatesSubtraction(double arg1, double arg2, double expectedResult)
        {
            var result = _subtraction.CalculateResult(new Argument(arg1), new Argument(arg2));

            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}
