using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("");
            Interpreter interpreter = new Interpreter();
            string option =  Console.ReadLine();
            if (option == "F")
            {
                string path = Console.ReadLine();
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    while (line!=null)
                    {
                        lexer = new Lexer(line);
                        Parser parser = new Parser(lexer.GetTokens());
                        List<Stmt> stmts = parser.Parse();
                        interpreter.Interpret(stmts);
                        line = sr.ReadLine();
                    }
                }
                Console.ReadLine();
            }
            else if(option == "S")
            {
                while (true)
                {
                    Console.Write("j++>");
                    lexer = new Lexer(Console.ReadLine());
                    Parser parser = new Parser(lexer.GetTokens());
                    List<Stmt> stmts = parser.Parse();
                    interpreter.Interpret(stmts);
                }
            }
            
        }
    }
}
