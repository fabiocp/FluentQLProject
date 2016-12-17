using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultBooleanoFiltroGerador : IFiltroGerador{

        private readonly SqlDefaultMontadorValor montadorValor;
        public SqlDefaultBooleanoFiltroGerador(SqlDefaultMontadorValor montadorValor) {
            this.montadorValor = montadorValor;
        }
        public string Gerar(QLExpr qlExpr) {

            switch (qlExpr.Operacao) {
                case QLOperation.Igual: return montadorValor.MontarExpressaoPadrao(qlExpr, "=");
                case QLOperation.Diferente: return montadorValor.MontarExpressaoPadrao(qlExpr, "<>");
            }

            return null;
        }

    }
}
