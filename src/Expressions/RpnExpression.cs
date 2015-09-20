using System;
using System.Collections.Generic;
using System.Linq;

namespace Expressions
{
    public class RpnExpression
    {
        private readonly IEnumerable<Token> _tokens;

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

            _tokens = tokens;
        }

        public double CalculateResult()
        {
            var stack = new Stack<Argument>();

            foreach (var token in _tokens)
            {
                HandleToken(token, stack);
            }

            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Invalid RPN Expression");
            }

            return stack.Pop().Value;
        }

        public override string ToString()
        {
            return _tokens.Select(t => t.ToString()).Aggregate((a, v) => a += $" {v}").Trim();
        }

        private void HandleToken(Token token, Stack<Argument> stack)
        {
            switch (token.Type)
            {
                case Token.TokenType.Argument:
                    stack.Push((Argument)token);
                    break;

                case Token.TokenType.Operator:
                    stack.Push(ExecuteOperator((Operator)token, stack));
                    break;

                default:
                    throw new ArgumentException("Unknown token type", nameof(token));
            }
        }

        private Argument ExecuteOperator(Operator op, Stack<Argument> stack)
        {
            if (stack.Count < 2)
            {
                throw new InvalidOperationException("Too few arguments for operator");
            }

            var arg2 = stack.Pop();
            var arg1 = stack.Pop();

            return op.CalculateResult(arg1, arg2);
        }
    }
}
