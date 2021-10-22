using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Lexer
    {
        public string text;
        public int pos;
        public Token current_token;
        public List<Token> tokens;

        public Lexer(string code)
        {
            text = code;
            pos = 0;
            current_token = null;
            tokens = new List<Token>();
        }
        public void Lex()
        {
            while (pos < text.Length)
            {
                if(text[pos]==' ')
                {
                    SkipWhitespace();
                    continue;
                }
                string value;
                if (Char.IsDigit(text[pos]))
                {
                    value = Integer();
                    Token tok = new Token(value, TokenType.INTEGER);
                    tokens.Add(tok);
                    continue;
                }
                if ("+-*/^".Contains(text[pos]))
                {
                    Token tok = new Token(text[pos].ToString(), TokenType.BINOP);
                    pos++;
                    tokens.Add(tok);
                    continue;
                }
                if (text[pos] == '=')
                {
                    pos++;
                    Token tok = new Token("=", TokenType.ASSIGN);
                    tokens.Add(tok);
                    continue;
                }
                if (text[pos] == '(')
                {
                    pos++;
                    Token tok = new Token("(", TokenType.LPAREN);
                    tokens.Add(tok);
                    continue;
                }
                if (text[pos] == ')')
                {
                    pos++;
                    Token tok = new Token(")", TokenType.RPAREN);
                    tokens.Add(tok);
                    continue;
                }
                if(text[pos] == '"')
                {
                    pos++;
                    value = String();
                    Token tok = new Token(value, TokenType.STRING);
                    tokens.Add(tok);
                    continue;
                }
                if (char.IsLetter(text[pos]))
                {
                    string lit = Literal();
                    Token tok = new Token(lit, TokenType.IDENTIFIER);
                    tokens.Add(tok);
                    continue;
                }
            }
            Token eof_tok = new Token(" ", TokenType.EOF);
            tokens.Add(eof_tok);
        }
        public void SkipWhitespace() {
            while (text[pos] == ' ') pos++;
        }
        public string Integer() {
            string num = "";
            while (pos < text.Length && char.IsDigit(text[pos]))
            {
                num += text[pos];
                pos++;
            }
            return num;
        }
        public string Literal()
        {
            string word = "";
            while (pos < text.Length && (char.IsLetter(text[pos]) || text[pos]=='_'))
            {
                word += text[pos];
                pos++;
            }
            return word;
        }
        public string String()
        {
            string str = "";
            while (pos < text.Length && text[pos]!='"')
            {
                str += text[pos];
                pos++;
            }
            return str;
        }
    }
}
