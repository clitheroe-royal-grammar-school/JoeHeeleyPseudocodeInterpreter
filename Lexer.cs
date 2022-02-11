using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Lexer
    {
        private string text;
        private int pos;
        private List<Token> tokens;
        public List<Token> GetTokens()
        {
            return tokens;
        }
        public Lexer(string code)
        {
            text = code;
            pos = 0;
            tokens = new List<Token>();
            Lex();
        }
        private void Lex()
        {
            while (pos < text.Length)
            {
                string value;
                switch (text[pos])
                {
                    case '+':
                        tokens.Add(new Token("+", TokenType.PLUS, null));
                        pos++;
                        break;
                    case '/':
                        tokens.Add(new Token("/", TokenType.DIVIDE, null));
                        pos++;
                        break;
                    case '*':
                        tokens.Add(new Token("*", TokenType.MULTIPLY, null));
                        pos++;
                        break;
                    case '>':
                        if (pos < text.Length - 1 && text[pos + 1] == '=')
                        {
                            tokens.Add(new Token(">=", TokenType.G_EQUAL, null));
                            pos++;
                        }
                        else tokens.Add(new Token(">", TokenType.G_THAN, null));
                        pos++;
                        break;
                    case '<':
                        if (pos < text.Length - 1 && text[pos + 1] == '=')
                        {
                            tokens.Add(new Token("<=", TokenType.L_EQUAL, null));
                            pos++;
                        }
                        else tokens.Add(new Token("<", TokenType.L_THAN, null));
                        pos++;
                        break;
                    case '!':
                        if (pos < text.Length - 1 && text[pos + 1] == '=')
                        {
                            tokens.Add(new Token("!=", TokenType.NOT_EQUAL, null));
                            pos++;
                        }
                        else tokens.Add(new Token("!", TokenType.NOT, null)); ;
                        pos++;
                        break;
                    case '-':
                        tokens.Add(new Token("-", TokenType.MINUS, null));
                        pos++;
                        break;
                    case '=':
                        if (pos < text.Length - 1 && text[pos + 1] == '=')
                        {
                            tokens.Add(new Token("==", TokenType.EQUAL, null));
                            pos++;
                        }
                        else tokens.Add(new Token("=", TokenType.ASSIGN, null));
                        pos++;
                        break;
                    case ' ':
                        int count = SkipWhitespace();
                        if (count == 3)
                        {
                            tokens.Add(new Token(null, TokenType.INDENT, null));
                        }
                        break;
                    case '(':
                        tokens.Add(new Token("(", TokenType.LBRACK, null));
                        pos++;
                        break;
                    case ')':
                        tokens.Add(new Token(")", TokenType.RBRACK, null));
                        pos++;
                        break;
                    case '"':
                        pos++;
                        value = String();
                        Token tok = new Token(value, TokenType.STRING, value);
                        tokens.Add(tok);
                        break;
                    default:
                        if(Char.IsDigit(text[pos]))
                        {
                            value = Integer();
                            tokens.Add(new Token(value, TokenType.INTEGER, int.Parse(value)));
                            break;
                        }
                        if (char.IsLetter(text[pos]))
                        {
                            value = Literal();
                            if (value == "true" | value == "false")
                            {
                                tokens.Add(new Token(value, TokenType.BOOL, value == "true"));
                                break;
                            }
                            if (value == "None")
                            {
                                tokens.Add(new Token(value, TokenType.NONE, null));
                                break;
                            }
                            if(value == "OUTPUT")
                            {
                                tokens.Add(new Token(value, TokenType.OUTPUT, null));
                                break;
                            }
                            if (value == "VAR")
                            {
                                tokens.Add(new Token(value, TokenType.VAR, null));
                                break;
                            }
                            tokens.Add(new Token(value, TokenType.IDENTIFIER, null));
                            break;
                        }
                        Token eof_tok = new Token(" ", TokenType.EOF, null);
                        tokens.Add(eof_tok);
                        break;
                }      
            }       
        }
        private int SkipWhitespace() {
            int count = 0;
            while (text[pos] == ' ')
            {
                pos++;
                count++;
            }
            return count;
        }
        private string Integer() {
            string num = "";
            while (pos < text.Length && char.IsDigit(text[pos]))
            {
                num += text[pos];
                pos++;
            }
            return num;
        }
        private string Literal()
        {
            string word = "";
            while (pos < text.Length && (char.IsLetter(text[pos]) || text[pos]=='_'))
            {
                word += text[pos];
                pos++;
            }
            return word;
        }
        private string String()
        {
            string str = "";
            while (pos < text.Length && text[pos]!='"')
            {
                str += text[pos];
                pos++;
            }
            pos++;
            return str;
        }
    }
}
