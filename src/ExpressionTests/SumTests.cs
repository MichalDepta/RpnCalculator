using Expressions.Operators;
using NUnit.Framework;

namespace ExpressionTests
{
    [TestFixture]
    public class SumTests
    {
        private SumOperator _sum = new SumOperator();

        [Test]
        [TestCase(4, 8, 12)]
        [TestCase(0, 14.3, 14.3)]
        [TestCase(-84.97, 10, -74.97)]
        public void CalculatesSum(double arg1, double arg2, double expectedResult)
        {
            var result = _sum.CalculateResult(arg1, arg2);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
