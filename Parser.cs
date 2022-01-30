using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoePlusPlus
{
    class Parser
    {
        public List<Token> tokens;
        private int curr;
        public Expr result;
        public Parser(List<Token> toks)
        {
            tokens = toks;
            curr = 0;
            result = Expression();
        }
        private Expr Expression()
        {
            return Equality();
        }
        private Expr Equality()
        {
            Expr expr = Comparison();
            List<TokenType> types = new List<TokenType>{ TokenType.NOT_EQUAL, TokenType.EQUAL };
            while (Match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = Comparison();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr Comparison()
        {
            Expr expr = Term();
            List<TokenType> types = new List<TokenType> { TokenType.G_THAN, TokenType.G_EQUAL, TokenType.L_THAN, TokenType.L_EQUAL };
            while (Match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = Term();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr Term()
        {
            Expr expr = Factor();
            List<TokenType> types = new List<TokenType> { TokenType.MINUS, TokenType.PLUS };
            while (Match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = Factor();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr Factor()
        {
            Expr expr = Unary();
            List<TokenType> types = new List<TokenType> { TokenType.DIVIDE, TokenType.MULTIPLY };
            while (Match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = Unary();
                expr = new ExprBinary(expr, op, right);
            }
            return expr;
        }
        private Expr Unary()
        {
            List<TokenType> types = new List<TokenType> { TokenType.NOT, TokenType.MINUS };
            if (Match(types))
            {
                Token op = tokens[curr - 1];
                Expr right = Unary();
                return new ExprUnary(op, right);
            }
            return Primary();
        }
        private Expr Primary()
        {
            if (Match(TokenType.INTEGER)) return new ExprLiteral(tokens[curr - 1].GetObj());
            if (Match(TokenType.STRING)) return new ExprLiteral(tokens[curr - 1].GetObj());
            if (Match(TokenType.BOOL)) return new ExprLiteral(tokens[curr - 1].GetObj());
            if (Match(TokenType.NONE)) return new ExprLiteral(tokens[curr - 1].GetObj());
            if (Match(TokenType.LBRACK))
            {
                ExprGrouping expr = new ExprGrouping(Expression());
                Match(TokenType.RBRACK);
                return expr;
            }
            return null;
        }
        private bool Match(List<TokenType> types)
        {
            foreach(TokenType type in types)
            {
                if(curr < tokens.Count && tokens[curr].GetTokenType() == type)
                {
                    curr++;
                    return true;
                }
            }

            return false;
        }
        private bool Match(TokenType type)
        {
            if (curr < tokens.Count && tokens[curr].GetTokenType() == type)
            {
                curr++;
                return true;
            }
            return false;
        }
    }
}
