namespace Expressions
{
    public abstract class Operator : Token
    {
        protected Operator() : base(TokenType.Operator)
        {
        }

        public abstract double CalculateResult(double arg1, double arg2);
    }
}