using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQLProject.FluentQL {
    public class QLExpr {

        public string NomeFiltro { get;  set; }
        public QLOperation Operacao { get; private set; }
        public object Valor { get; private set; }
        public QLExpr ExprInterna {get; private set;}

        public string ExprCustomizada { get; private set; }

        public QLExpr ExprAtual { get; private set; }
        public QLOperadorLogico? OperadorLogico { get; private set; }

        public QLExpr ExprProximo {get; private set;}

        public QLExpr(string nomeFiltro, QLOperation operacao, object valor) {
            this.NomeFiltro = nomeFiltro;
            this.Operacao = operacao;
            this.Valor = valor;
            this.ExprAtual = this;
        }

        public QLExpr(QLExpr expr) {
            this.ExprInterna = expr;
            this.ExprAtual = this;
        }

        public QLExpr(QLExpr expr, QLOperadorLogico ol): this(expr) {
            this.OperadorLogico = ol;
        }

        public QLExpr(string exprCustomizada) {
            this.ExprCustomizada = exprCustomizada;
            this.ExprAtual = this;
        }

        public QLExpr(string exprCustomizada, QLOperadorLogico ol) : this(exprCustomizada){
            this.OperadorLogico = ol;
        }

        public QLExpr(string nomeFiltro, QLOperation operacao, object valor, QLOperadorLogico ol): this(nomeFiltro, operacao, valor) {
            this.OperadorLogico = ol;
        }

        public QLExpr And(string nomeFiltro, QLOperation operacao, object valor) {
            return AddProximo(nomeFiltro, operacao, valor, QLOperadorLogico.AND);
        }

        public QLExpr And(QLExpr expr) {
            return AddProximo(expr, QLOperadorLogico.AND);
        }

        public QLExpr And(string expr) {
            return AddProximo(expr, QLOperadorLogico.AND);
        }

        public QLExpr Or(string expr) {
            return AddProximo(expr, QLOperadorLogico.OR);
        }

        public QLExpr Or(string nomeFiltro, QLOperation operacao, object valor) {
            return AddProximo(nomeFiltro, operacao, valor, QLOperadorLogico.OR);
        }

        public QLExpr Or(QLExpr expr) {
            return AddProximo(expr, QLOperadorLogico.OR);
        }

        private QLExpr AddProximo(string nomeFiltro, QLOperation operacao, object valor, QLOperadorLogico operadorLogico) {
            this.ExprAtual.ExprProximo = new QLExpr(nomeFiltro, operacao, valor, operadorLogico);
            this.ExprAtual = this.ExprAtual.ExprProximo;
            return this;
        }

        private QLExpr AddProximo(QLExpr expr, QLOperadorLogico operadorLogico) {
            this.ExprAtual.ExprProximo = new QLExpr(expr, operadorLogico);
            this.ExprAtual = this.ExprAtual.ExprProximo;
            return this;
        }

        private QLExpr AddProximo(string expr, QLOperadorLogico operadorLogico) {
            this.ExprAtual.ExprProximo = new QLExpr(expr, operadorLogico);
            this.ExprAtual = this.ExprAtual.ExprProximo;
            return this;
        }

    
        

    }
}
