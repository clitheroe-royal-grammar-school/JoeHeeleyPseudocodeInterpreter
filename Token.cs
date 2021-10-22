using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public enum TokenType
    {
        EOF,
        INTEGER,
        BINOP,
        LPAREN,
        RPAREN,
        IDENTIFIER,
        STRING,
        ASSIGN,
    }
    class Token
    {
        public string value;
        public TokenType type;
        public Token(string val,TokenType token_type)
        {
            value = val;
            type = token_type;
        }
        public override string ToString()
        {
            return "Token(" + value + "," + type + ")";
        }
    }
}
