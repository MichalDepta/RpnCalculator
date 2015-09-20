namespace Expressions
{
    public abstract class Operator : Token
    {
        protected Operator() : base(TokenType.Operator)
        {
        }

        public abstract Argument CalculateResult(Argument arg1, Argument arg2);
    }
}