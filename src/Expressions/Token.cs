namespace Expressions
{
    public abstract class Token
    {
        protected Token(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; }

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        protected abstract string GetStringRepresentation();

        public enum TokenType
        {
            Argument,
            Operator
        }
    }
}