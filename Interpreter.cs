using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Interpreter : Expr.Visitor<object>,Stmt.Visitor<object>
    {
        public Memory mem = new Memory();
        public void Interpret(List<Stmt> statements)
        {
            try
            {
                foreach(Stmt statement in statements)
                {
                    Execute(statement);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void Execute(Stmt stmt)
        {
            stmt.Accept(this);
        }
        public object VisitExprBinary(ExprBinary exprbinary)
        {
            object left = Evaluate(exprbinary.left);
            object right = Evaluate(exprbinary.right);
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

        public object VisitExprBrackets(ExprBrackets exprbrackets)
        {
            return Evaluate(exprbrackets.expression);
        }

        public object VisitExprLiteral(ExprLiteral exprliteral)
        {
            return exprliteral.value;
        }

        public object VisitExprUnary(ExprUnary exprunary)
        {
            object right = Evaluate(exprunary.right);
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
        public object Evaluate(Expr expr)
        {
            return expr.Accept(this);
        }

        public object VisitStmtExpression(StmtExpression stmt)
        {
            Evaluate(stmt.expression);
            return null;
        }

        public object VisitStmtOutput(StmtOutput stmt)
        {
            object result = Evaluate(stmt.expression);
            Console.WriteLine(result.ToString());
            return null;
        }

        public object VisitStmtVar(StmtVar stmt)
        {
            object value = null;
            if (stmt.initial != null)
            {
                value = Evaluate(stmt.initial);
            }
            mem.Define(stmt.name.value, value);
            return null;
        }

        public object VisitExprVariable(ExprVariable expr)
        {
            return mem.Get(expr.name);
        }

        public object VisitExprAssignment(ExprAssignment expr)
        {
            throw new NotImplementedException();
        }
    }
}
