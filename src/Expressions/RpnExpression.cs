using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    public class RpnExpression
    {
        public RpnExpression(IEnumerable<Token> tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }
            
            if (!tokens.Any())
            {
                throw new ArgumentException("tokens list cannot be empty");
            }
        }

        public double CalculateResult()
        {
            throw new NotImplementedException();
        }
    }
}
