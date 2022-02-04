using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interpreter{
	abstract class Stmt{
		public abstract T Accept<T>(Visitor<T> vis);
		public interface Visitor<T>{
			T VisitStmtExpression(StmtExpression stmt);
			T VisitStmtOutput(StmtOutput stmt);
			T VisitStmtVar(StmtVar stmt);
		}
	}
	class StmtExpression:Stmt{
		public Expr expression;
		public StmtExpression(Expr expression){
			this.expression=expression;
		}
		public override T Accept<T>(Stmt.Visitor<T> vis){
			return vis.VisitStmtExpression(this);
		}
	}
	class StmtOutput:Stmt{
		public Expr expression;
		public StmtOutput(Expr expression){
			this.expression=expression;
		}
		public override T Accept<T>(Stmt.Visitor<T> vis){
			return vis.VisitStmtOutput(this);
		}
	}
	class StmtVar:Stmt{
		public Token name;
		public Expr initial;
		public StmtVar(Token name,Expr initial){
			this.name=name;
			this.initial=initial;
		}
		public override T Accept<T>(Stmt.Visitor<T> vis){
			return vis.VisitStmtVar(this);
		}
	}
}