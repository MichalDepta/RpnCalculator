using System;
using System.Collections.Generic;
using System.Globalization;
using Expressions.Operators;

namespace Expressions
{
    public class TokenFactory
    {
        private static readonly Dictionary<string, Func<Token>> TokenFactories = new Dictionary<string, Func<Token>>
        {
            ["+"] = () => new SumOperator(),
            ["-"] = () => new SubtractOperator(),
            ["*"] = () => new MultiplicationOperator(),
            ["/"] = () => new DivisionOperator()
        };

        public static bool IsValidTokenString(string candidate)
        {
            return TokenFactories.ContainsKey(candidate) || IsNumber(candidate);
        }

        public static Token CreateToken(string tokenString)
        {
            if (TokenFactories.ContainsKey(tokenString))
            {
                return TokenFactories[tokenString]();
            }

            double number;
            if (!TryParseNumber(tokenString, out number))
            {
                throw new ArgumentException($"Could not parse {tokenString}", nameof(tokenString));
            }

            return new Argument(number);
        }

        private static bool IsNumber(string candidate)
        {
            double _;
            return TryParseNumber(candidate, out _);
        }

        private static bool TryParseNumber(string numberString, out double number) => double.TryParse(numberString, NumberStyles.Float, CultureInfo.InvariantCulture, out number);

    }
}