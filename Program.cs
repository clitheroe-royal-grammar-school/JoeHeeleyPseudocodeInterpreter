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
                lexer.Lex();
                foreach(Token tok in lexer.tokens)
                {
                    Console.WriteLine(tok);
                }
            }
        }
    }
}
