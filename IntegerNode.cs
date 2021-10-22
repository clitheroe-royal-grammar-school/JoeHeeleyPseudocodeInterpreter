using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class IntegerNode:ASTNode
    {
        public Token token;
        public IntegerNode(Token tok)
        {
            token = tok;
        }
        public override string ToString()
        {
            return $"{token}";
        }
    }
}
