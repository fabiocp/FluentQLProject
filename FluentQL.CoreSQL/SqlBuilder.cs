using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQLProject.FluentQL.CoreSQL {
    public class SqlBuilder {

        private readonly QLExpr qlExpr;
        private readonly IEnumerable<FiltroDefinicao> filtroDefinicaoList;
        private readonly FabricaFiltro fabricaFiltro;
        public SqlBuilder(QLExpr qlExpr, IEnumerable<FiltroDefinicao> filtroDefinicaoList, FabricaFiltro fabricaFiltro) {
            this.qlExpr = qlExpr;
            this.filtroDefinicaoList = filtroDefinicaoList;
            this.fabricaFiltro = fabricaFiltro;
        }

        public string Gerar() {
            return Gerar(this.qlExpr);
        }

        private string Gerar(QLExpr qlExprParam) {
            var str = "";
            var expr = qlExprParam;
            while (expr != null) {
                var expressaoStr = GerarIndividual(expr);
                if (!string.IsNullOrEmpty(expressaoStr)) {
                    if (expr.OperadorLogico != null)
                        str += " " + GetStrOperador((QLOperadorLogico)expr.OperadorLogico) + " ";

                    str += "(" + expressaoStr + ")";
                }
                expr = expr.ExprProximo;
            }
            return str;
        }

        private string GerarIndividual(QLExpr qlExprParam) {
            if (qlExprParam.ExprInterna != null)
                return Gerar(qlExprParam.ExprInterna);

            if (!string.IsNullOrEmpty(qlExprParam.ExprCustomizada))
                return qlExprParam.ExprCustomizada;

            var filtroDefinicao = filtroDefinicaoList.FirstOrDefault(f => f.NomeFiltro == qlExprParam.NomeFiltro);
            if (filtroDefinicao != null) 
                return fabricaFiltro.Gerar(filtroDefinicao, qlExprParam);

            return "";
        }


        private string GetStrOperador(QLOperadorLogico operadorLogico) {
            switch (operadorLogico) {
                case QLOperadorLogico.AND: return "and";
                case QLOperadorLogico.OR: return "or";
                default: return "";
            }
        }
    }
}
