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
        public static Interpreter interpreter = new Interpreter();
        static void Main(string[] args)
        {
            Lexer lexer;
            string option =  Console.ReadLine();
            if (option == "F")
            {
                
                string path = Console.ReadLine();
                
                using (StreamReader sr = new StreamReader(path))
                {
                    string code = sr.ReadToEnd();
                    lexer = new Lexer(code);
                    foreach (Token tok in lexer.GetTokens())
                    {
                        Console.WriteLine(tok);
                    }
                    Parser parser = new Parser(lexer.GetTokens());
                    List<Stmt> stmts = parser.Parse();
                    foreach (Stmt stmt in stmts)
                    {
                        Console.WriteLine(stmt.GetType());
                    }
                    interpreter.Interpret(stmts);
                    /*
                    string line = sr.ReadLine();
                    while (line!=null)
                    {
                        lexer = new Lexer(line);
                        Parser parser = new Parser(lexer.GetTokens());
                        List<Stmt> stmts = parser.Parse();
                        interpreter.Interpret(stmts);
                        line = sr.ReadLine();
                    }
                    */
                }
                Console.ReadLine();
            }
            else if(option == "S")
            {
                while (true)
                {
                    Console.Write("j++>");
                    lexer = new Lexer(Console.ReadLine());
                    foreach (Token tok in lexer.GetTokens())
                    {
                        Console.WriteLine(tok);
                    }
                    Parser parser = new Parser(lexer.GetTokens());
                    List<Stmt> stmts = parser.Parse();
                    foreach(Stmt stmt in stmts)
                    {
                        Console.WriteLine(stmt.GetType());
                    }
                    interpreter.Interpret(stmts);
                    foreach(string var in interpreter.mem.variables.Keys)
                    {
                        Console.WriteLine(var + ':' + interpreter.mem.variables[var]);
                    }
                }
            }
            
        }
    }
}
