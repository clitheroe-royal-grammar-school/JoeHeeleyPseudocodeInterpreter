using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interpreter{
	abstract class Expr{
		public abstract T Accept<T>(Visitor<T> vis);
		public interface Visitor<T>{
			T VisitExprBinary(ExprBinary expr);
			T VisitExprBrackets(ExprBrackets expr);
			T VisitExprLiteral(ExprLiteral expr);
			T VisitExprUnary(ExprUnary expr);
			T VisitExprVariable(ExprVariable expr);
			T VisitExprAssignment(ExprAssignment expr);
		}
	}
	class ExprBinary:Expr{
		public Expr left;
		public Token op;
		public Expr right;
		public ExprBinary(Expr left,Token op,Expr right){
			this.left=left;
			this.op=op;
			this.right=right;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprBinary(this);
		}
	}
	class ExprBrackets:Expr{
		public Expr expression;
		public ExprBrackets(Expr expression){
			this.expression=expression;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprBrackets(this);
		}
	}
	class ExprLiteral:Expr{
		public object value;
		public ExprLiteral(object value){
			this.value=value;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprLiteral(this);
		}
	}
	class ExprUnary:Expr{
		public Token op;
		public Expr right;
		public ExprUnary(Token op,Expr right){
			this.op=op;
			this.right=right;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprUnary(this);
		}
	}
	class ExprVariable:Expr{
		public Token name;
		public ExprVariable(Token name){
			this.name=name;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprVariable(this);
		}
	}
	class ExprAssignment:Expr{
		public Token name;
		public Expr value;
		public ExprAssignment(Token name,Expr value){
			this.name=name;
			this.value=value;
		}
		public override T Accept<T>(Expr.Visitor<T> vis){
			return vis.VisitExprAssignment(this);
		}
	}
}