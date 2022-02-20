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
        BOOL,
        LBRACK,
        RBRACK,
        IDENTIFIER,
        STRING,
        ASSIGN,
        NONE,
        NOT,
        NOT_EQUAL,
        EQUAL,
        G_THAN,
        G_EQUAL,
        L_THAN,
        L_EQUAL,
        PLUS,
        MINUS,
        DIVIDE,
        MULTIPLY,
        OUTPUT,
        VAR,
        INDENT,
        NEWLINE,
    }
    class Token
    {
        public string value;
        public TokenType type;
        public object obj;
        public Token(string value,TokenType type,object obj)
        {
            this.value = value;
            this.type = type;
            this.obj = obj;

        }
        public override string ToString()
        {
            return "Token(" + value + "," + type + ")";
        }
    }
}
