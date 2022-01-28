using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Interpreter : Visitor<object>
    {
        public void interpret(Expr expression)
        {
            try
            {
                object value = evaluate(expression);
                Console.WriteLine(value.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public object visitExprBinary(ExprBinary exprbinary)
        {
            object left = evaluate(exprbinary.left);
            object right = evaluate(exprbinary.right);
            switch (exprbinary.op.type)
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

        public object visitExprGrouping(ExprGrouping exprgrouping)
        {
            return evaluate(exprgrouping.expression);
        }

        public object visitExprLiteral(ExprLiteral exprliteral)
        {
            return exprliteral.value;
        }

        public object visitExprUnary(ExprUnary exprunary)
        {
            object right = evaluate(exprunary.right);
            if (exprunary.op.type == TokenType.MINUS)
            {
                return -(int)right;
            }
            if (exprunary.op.type == TokenType.NOT)
            {
                return !(bool)right;
            }
            return null;
        }
        public object evaluate(Expr expr)
        {
            return expr.accept(this);
        }
    }
}
