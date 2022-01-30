using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoePlusPlus
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
    }
    class Token
    {
        private string value;
        private TokenType type;
        private object obj;
        public Token(string value,TokenType type,object obj)
        {
            this.value = value;
            this.type = type;
            this.obj = obj;

        }
        public object GetObj()
        {
            return obj;
        }
        public string GetValue()
        {
            return value;
        }
        public TokenType GetTokenType()
        {
            return type;
        }
        public override string ToString()
        {
            return "Token(" + value + "," + type + ")";
        }
    }
}
