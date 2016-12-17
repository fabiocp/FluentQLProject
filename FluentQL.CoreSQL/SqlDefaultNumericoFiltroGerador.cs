using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultNumericoFiltroGerador : IFiltroGerador {

        private readonly SqlDefaultMontadorValor montadorValor;
        public SqlDefaultNumericoFiltroGerador(SqlDefaultMontadorValor montadorValor) {
            this.montadorValor = montadorValor;
        }
        public string Gerar(QLExpr qlExpr) {

            switch (qlExpr.Operacao) {
                case QLOperation.Igual: return montadorValor.MontarExpressaoPadrao(qlExpr, "=");
                case QLOperation.Entre: return montadorValor.MontarExpressaoPadrao(qlExpr, "in", "({valor})");
                case QLOperation.Maior: return montadorValor.MontarExpressaoPadrao(qlExpr, ">");
                case QLOperation.MaiorIgual: return montadorValor.MontarExpressaoPadrao(qlExpr, ">=");
                case QLOperation.Menor: return montadorValor.MontarExpressaoPadrao(qlExpr, "<");
                case QLOperation.MenorIgual: return montadorValor.MontarExpressaoPadrao(qlExpr, "<=");
                case QLOperation.Diferente: return montadorValor.MontarExpressaoPadrao(qlExpr, "<>");
            }

            return null;
        }
    }
}
