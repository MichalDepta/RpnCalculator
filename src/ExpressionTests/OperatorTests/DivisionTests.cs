using Expressions;
using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests.OperatorTests
{
    [TestFixture]
    public class DivisionTests
    {
        private DivisionOperator _division = new DivisionOperator();

        [Test]
        [TestCase(56, 7, 8)]
        [TestCase(-72, 9, -8)]
        [TestCase(10.5, 3, 3.5)]
        public void CalculatesDivision(double arg1, double arg2, double expectedResult)
        {
            var result = _division.CalculateResult(new Argument(arg1), new Argument(arg2));

            Assert.AreEqual(expectedResult, result.Value);
        }
    }
}
