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
        private int curr;
        public Expr ans;
        public Parser(List<Token> toks)
        {
            tokens = toks;
            curr = 0;
            ans = expression();
        }
        private Expr expression()
        {
            return equality();
        }
        private Expr equality()
        {
            Expr expr = comparison();
            List<TokenType> types = new List<TokenType>{ TokenType.NOT_EQUAL, TokenType.EQUAL };
            while (match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = comparison();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr comparison()
        {
            Expr expr = term();
            List<TokenType> types = new List<TokenType> { TokenType.G_THAN, TokenType.G_EQUAL, TokenType.L_THAN, TokenType.L_EQUAL };
            while (match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = term();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr term()
        {
            Expr expr = factor();
            List<TokenType> types = new List<TokenType> { TokenType.MINUS, TokenType.PLUS };
            while (match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = factor();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr factor()
        {
            Expr expr = unary();
            List<TokenType> types = new List<TokenType> { TokenType.DIVIDE, TokenType.MULTIPLY };
            while (match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = unary();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr unary()
        {
            List<TokenType> types = new List<TokenType> { TokenType.NOT, TokenType.MINUS };
            if (match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = unary();
                return new ExprUnary(op, right);
            }
            return primary();
        }
        private Expr primary()
        {
            if (match(TokenType.INTEGER)) return new ExprLiteral(tokens[curr - 1].obj);
            if (match(TokenType.STRING)) return new ExprLiteral(tokens[curr - 1].obj);
            if (match(TokenType.BOOL)) return new ExprLiteral(tokens[curr - 1].obj);
            if (match(TokenType.NONE)) return new ExprLiteral(tokens[curr - 1].obj);
            if (match(TokenType.LBRACK))
            {
                ExprGrouping expr = new ExprGrouping(expression());
                match(TokenType.RBRACK);
                return expr;
            }
            return null;
        }
        private bool match(List<TokenType> types)
        {
            foreach(TokenType type in types)
            {
                if(curr < tokens.Count && tokens[curr].type == type)
                {
                    curr++;
                    return true;
                }
            }

            return false;
        }
        private bool match(TokenType type)
        {
            if (curr < tokens.Count && tokens[curr].type == type)
            {
                curr++;
                return true;
            }
            return false;
        }
    }
}
