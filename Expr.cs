using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Interpreter{
	abstract class Expr{
		public abstract T accept<T>(Visitor<T> vis);
	}
	interface Visitor<T>{
		T visitExprBinary(ExprBinary exprbinary);
		T visitExprGrouping(ExprGrouping exprgrouping);
		T visitExprLiteral(ExprLiteral exprliteral);
		T visitExprUnary(ExprUnary exprunary);
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
	public override T accept<T>(Visitor<T> vis){
		return vis.visitExprBinary(this);
	}
	}
class ExprGrouping:Expr{
	public Expr expression;
	public ExprGrouping(Expr expression){
		this.expression=expression;
		}
	public override T accept<T>(Visitor<T> vis){
		return vis.visitExprGrouping(this);
	}
	}
class ExprLiteral:Expr{
	public object value;
	public ExprLiteral(object value){
		this.value=value;
		}
	public override T accept<T>(Visitor<T> vis){
		return vis.visitExprLiteral(this);
	}
	}
class ExprUnary:Expr{
	public Token op;
	public Expr right;
	public ExprUnary(Token op,Expr right){
		this.op=op;
		this.right=right;
		}
	public override T accept<T>(Visitor<T> vis){
		return vis.visitExprUnary(this);
	}
	}
}