using System;
using System.Linq;
using Expressions;

namespace RpnConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RPN calculator!");
            Console.WriteLine("Type RPN expressions. Separate tokens with whitespace!");

            var tokenizer = new InputTokenizer();

            while (true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine();
                if (input?.Trim().ToLower().Equals("quit") ?? false)
                {
                    break;
                }

                try
                {
                    var tokens = tokenizer.Tokenize(input);
                    var expression = new RpnExpression(tokens);
                
                    Console.WriteLine($"-> {expression.CalculateResult()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Bye Bye!");
            Console.ReadKey();
        }
    }
}