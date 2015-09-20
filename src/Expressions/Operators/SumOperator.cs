namespace Expressions.Operators
{
    public class SumOperator : Operator
    {
        public override double CalculateResult(double arg1, double arg2)
        {
            return arg1 + arg2;
        }

        protected override string GetStringRepresentation()
        {
            return "+";
        }
    }
}
