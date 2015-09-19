using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    public class RpnExpression
    {
        public RpnExpression(Queue<Argument> arguments, Stack<Operator> operators)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            if (operators == null)
            {
                throw new ArgumentNullException(nameof(operators));
            }

            if (!arguments.Any())
            {
                throw new ArgumentException("Arguments list cannot be empty");
            }
        }

        public double CalculateResult()
        {
            throw new NotImplementedException();
        }
    }
}
