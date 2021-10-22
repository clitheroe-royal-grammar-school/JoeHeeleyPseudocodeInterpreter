using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class BinOpNode: ASTNode
    {
        ASTNode left_node;
        ASTNode right_node;
        Token op;
        public BinOpNode(ASTNode left,Token erator,ASTNode right)
        {
            left_node = left;
            op = erator;
            right_node = right;
        }
        public override string ToString()
        {
            return $"{left_node} {op} {right_node}";
        }
    }
}
