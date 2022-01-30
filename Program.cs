using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoePlusPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("");
            while (true)
            {
                Console.Write("j++>");
                lexer = new Lexer(Console.ReadLine());
                Parser parser = new Parser(lexer.GetTokens());
                Interpreter interpreter = new Interpreter();
                interpreter.Interpret(parser.result);
            }
        }
    }
}
