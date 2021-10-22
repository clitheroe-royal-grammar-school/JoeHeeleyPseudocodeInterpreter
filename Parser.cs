using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Parser
    {
        public List<Token> tokens;
        public Parser(List<Token> toks)
        {
            tokens = toks;
            AST tree = new AST();
            tree = Statement();

        }
        public AST Statement() {
            return Expression();
        }
        public AST Expression() {
            return new AST();
        }
        public void Assignment() { }
        public void BoolTest() { }
        public void Arithmetic() { }

    }
}
