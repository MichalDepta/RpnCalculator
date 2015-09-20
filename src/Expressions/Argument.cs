using System.Globalization;

namespace Expressions
{
    public class Argument : Token
    {
        public Argument(double value) : base (TokenType.Argument)
        {
            Value = value;
        }

        public double Value { get; }

        protected override string GetStringRepresentation()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}