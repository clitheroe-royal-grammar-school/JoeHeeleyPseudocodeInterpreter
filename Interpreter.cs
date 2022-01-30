using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoePlusPlus
{
    class Interpreter : Visitor<object>
    {
        public void Interpret(Expr expression)
        {
            try
            {
                object value = Evaluate(expression);
                Console.WriteLine(value.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public object VisitExprBinary(ExprBinary expr_binary)
        {
            object left = Evaluate(expr_binary.left);
            object right = Evaluate(expr_binary.right);
            switch (expr_binary.op.GetTokenType())
            {
                case TokenType.MINUS:
                    return (int)left - (int)right;
                case TokenType.PLUS:
                    if (left.GetType().Equals(typeof(int)) && right.GetType().Equals(typeof(int)))
                    {
                        return (int)left + (int)right;
                    }
                    if(left.GetType().Equals(typeof(string)) && right.GetType().Equals(typeof(string)))
                    {
                        return left.ToString() + right.ToString();
                    }
                    break;
                case TokenType.DIVIDE:
                    return (int)left / (int)right;
                case TokenType.MULTIPLY:
                    return (int)left * (int)right;
                case TokenType.G_THAN:
                    return (int)left > (int)right;
                case TokenType.G_EQUAL:
                    return (int)left >= (int)right;
                case TokenType.L_THAN:
                    return (int)left < (int)right;
                case TokenType.L_EQUAL:
                    return (int)left <= (int)right;
                case TokenType.NOT_EQUAL:
                    return !left.Equals(right);
                case TokenType.EQUAL:
                    return left.Equals(right);
            }
            return null;
        }

        public object VisitExprGrouping(ExprGrouping expr_grouping)
        {
            return Evaluate(expr_grouping.expression);
        }

        public object VisitExprLiteral(ExprLiteral expr_literal)
        {
            return expr_literal.value;
        }

        public object VisitExprUnary(ExprUnary expr_unary)
        {
            object right = Evaluate(expr_unary.right);
            if (expr_unary.op.GetTokenType() == TokenType.MINUS)
            {
                return -(int)right;
            }
            if (expr_unary.op.GetTokenType() == TokenType.NOT)
            {
                return !(bool)right;
            }
            return null;
        }
        public object Evaluate(Expr expr)
        {
            return expr.Accept(this);
        }
    }
}
