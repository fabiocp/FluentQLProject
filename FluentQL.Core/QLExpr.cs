using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public class QLExpr {

        private IList<QLExpr> _qlExprList;
        public string NomeFiltro { get; set; }
        public QLOperation Operacao { get; private set; }
        public object Valor { get; private set; }
        public QLExpr ExprInterna { get; private set; }
        public string ExprCustomizada { get; set; }
        public QLExpr ExprAtual { get; private set; }
        public QLOperadorLogico? OperadorLogico { get; private set; }
        public QLExpr ExprProximo { get; private set; }
        public bool EhFiltroCustomizado { get; private set; }

        public IList<QLExpr> QLExprList {
            get {
                return _qlExprList ?? (_qlExprList = new List<QLExpr>());
            }
            private set{
                _qlExprList = value;
            }
        }

        public QLExpr(string nomeFiltro, QLOperation operacao, object valor) {
            this.NomeFiltro = nomeFiltro;
            this.Operacao = operacao;
            this.Valor = valor;
            this.ExprAtual = this;
        }

        public QLExpr(QLExpr expr) {
            this.ExprInterna = expr;
            QLExprList.Add(expr);
            this.ExprAtual = this;
        }

        public QLExpr(QLExpr expr, QLOperadorLogico ol)
            : this(expr) {
            this.OperadorLogico = ol;
        }

        public QLExpr(string exprCustomizada) {
            this.ExprCustomizada = exprCustomizada;
            this.ExprAtual = this;
        }

        public QLExpr(string exprCustomizada, QLOperadorLogico ol)
            : this(exprCustomizada) {
            this.OperadorLogico = ol;
        }

        public QLExpr(string nomeFiltroCustomizado, object valor) {
            this.NomeFiltro = nomeFiltroCustomizado;
            this.Valor = valor;
            this.EhFiltroCustomizado = true;
        }

        public QLExpr(string nomeFiltroCustomizado, object valor, QLOperadorLogico ol)
            : this(nomeFiltroCustomizado, valor) {
            this.OperadorLogico = ol;
        }

        public QLExpr(string nomeFiltro, QLOperation operacao, object valor, QLOperadorLogico ol)
            : this(nomeFiltro, operacao, valor) {
            this.OperadorLogico = ol;
        }

        public QLExpr And(string nomeFiltro, QLOperation operacao, object valor) {
            return AddProximo(new QLExpr(nomeFiltro, operacao, valor, QLOperadorLogico.AND));
        }

        public QLExpr And(QLExpr expr) {
            return AddProximo(new QLExpr(expr, QLOperadorLogico.AND));
        }

        public QLExpr And(string expr) {
            return AddProximo(new QLExpr(expr, QLOperadorLogico.AND));
        }

        public QLExpr And(string nomeFiltroCustomizavel, object valor) {
            return AddProximo(new QLExpr(nomeFiltroCustomizavel, valor, QLOperadorLogico.AND));
        }

        public QLExpr Or(string expr) {
            return AddProximo(new QLExpr(expr, QLOperadorLogico.OR));
        }

        public QLExpr Or(string nomeFiltro, QLOperation operacao, object valor) {
            return AddProximo(new QLExpr(nomeFiltro, operacao, valor, QLOperadorLogico.OR));
        }

        public QLExpr Or(QLExpr expr) {
            return AddProximo(new QLExpr(expr, QLOperadorLogico.OR));
        }

        private QLExpr AddProximo(QLExpr expr) {
            this.ExprAtual.ExprProximo = expr;
            QLExprList.Add(this.ExprAtual.ExprProximo);
            this.ExprAtual = this.ExprAtual.ExprProximo;
            return this;
        }

        public IEnumerable<QLExpr> GetFiltrosPorNome(string nome) {
            var list = new List<QLExpr>();
            var expressaoFind = QLExprList.FirstOrDefault(e => e.NomeFiltro == nome);
            if (expressaoFind != null)
                list.Add(expressaoFind);

            foreach (var expr in QLExprList) {
                list.AddRange(expr.GetFiltrosPorNome(nome));
            }
            return list;
        }

    }
}
