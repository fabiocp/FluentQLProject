using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultTextoFiltroGerador : IFiltroGerador{

        private readonly SqlDefaultMontadorValor montadorValor;
        public SqlDefaultTextoFiltroGerador(SqlDefaultMontadorValor montadorValor) {
            this.montadorValor = montadorValor;
        }
        public string Gerar(QLExpr qlExpr) {
            switch (qlExpr.Operacao) {
                case QLOperation.Igual: return montadorValor.MontarExpressaoPadrao(qlExpr, "=", "'{valor}'");
                case QLOperation.Contem: return montadorValor.MontarExpressaoPadrao(qlExpr, "like", "'%{valor}%'");
                case QLOperation.Diferente: return montadorValor.MontarExpressaoPadrao(qlExpr, "<>", "'{valor}'");
                case QLOperation.ComecaCom: return montadorValor.MontarExpressaoPadrao(qlExpr, "like", "'%{valor}'");
                case QLOperation.TerminaCom: return montadorValor.MontarExpressaoPadrao(qlExpr, "like", "'{valor}%'");
                default: return null;
            }
        }
    }
}
