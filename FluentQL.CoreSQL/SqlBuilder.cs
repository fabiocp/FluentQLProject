using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlBuilder : IBuilder {

        private readonly FabricaFiltro fabricaFiltro;
        public SqlBuilder(FabricaFiltro fabricaFiltro) {
            this.fabricaFiltro = fabricaFiltro;
        }

        public string Gerar(QLExpr qlExprParam) {
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

            return fabricaFiltro.Gerar(qlExprParam);
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
