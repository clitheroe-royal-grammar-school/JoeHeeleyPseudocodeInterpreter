using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
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
                Parser parser = new Parser(lexer.getTokens());
                Interpreter interpreter = new Interpreter();
                interpreter.interpret(parser.ans);
            }
        }
    }
}
