using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Expressions;

namespace RpnConsole
{
    public class InputTokenizer
    {
        private static readonly char[] Separators = {' ', '\t', '\n', '\r'};

        public IEnumerable<Token> Tokenize(string rpnExpression)
        {
            var tokens = rpnExpression.Split(Separators);

            if (tokens.Any(t => !TokenFactory.IsValidTokenString(t)))
            {
                throw new InvalidOperationException($"The following input is not a valid RPN expression: {rpnExpression}");
            }

            return tokens.Select(TokenFactory.CreateToken).ToList();
        }
    }
}