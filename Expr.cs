using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JoePlusPlus{
	abstract class Expr{
		public abstract T Accept<T>(Visitor<T> vis);
	}
	interface Visitor<T>{
		T VisitExprBinary(ExprBinary expr_binary);
		T VisitExprGrouping(ExprGrouping expr_grouping);
		T VisitExprLiteral(ExprLiteral expr_literal);
		T VisitExprUnary(ExprUnary expr_unary);
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
	public override T Accept<T>(Visitor<T> vis){
		return vis.VisitExprBinary(this);
	}
	}
class ExprGrouping:Expr{
	public Expr expression;
	public ExprGrouping(Expr expression){
		this.expression=expression;
		}
	public override T Accept<T>(Visitor<T> vis){
		return vis.VisitExprGrouping(this);
	}
	}
class ExprLiteral:Expr{
	public object value;
	public ExprLiteral(object value){
		this.value=value;
		}
	public override T Accept<T>(Visitor<T> vis){
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
	public override T Accept<T>(Visitor<T> vis){
		return vis.VisitExprUnary(this);
	}
	}
}