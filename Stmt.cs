using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JoePlusPlus{
	abstract class Stmt{
		public abstract T Accept<T>(Visitor<T> vis);
	}
	interface Visitor<T>{
		T VisitStmtExpression(StmtExpression stmt_expression);
		T VisitStmtOutput(StmtOutput stmt_output);
	}
class StmtExpression:Stmt{
	public Expr expression;
	public StmtExpression(Expr expression){
		this.expression=expression;
		}
	public override T Accept<T>(Visitor<T> vis){
		return vis.VisitStmtExpression(this);
	}
	}
class StmtOutput:Stmt{
	public Expr expression;
	public StmtOutput(Expr expression){
		this.expression=expression;
		}
	public override T Accept<T>(Visitor<T> vis){
		return vis.VisitStmtOutput(this);
	}
	}
}