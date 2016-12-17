using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultDataFiltroGerador : IFiltroGerador {

        private readonly SqlDefaultMontadorValor montadorValor;
        public SqlDefaultDataFiltroGerador(SqlDefaultMontadorValor montadorValor) {
            this.montadorValor = montadorValor;
        }

        public string Gerar(QLExpr qlExpr) {
            switch (qlExpr.Operacao) {
                case QLOperation.Igual: return qlExpr.NomeFiltro + " = " + montadorValor.MontarValor(qlExpr.Valor);
                case QLOperation.MaiorIgual: return qlExpr.NomeFiltro + " >= " + montadorValor.MontarValor(qlExpr.Valor);
            }

            return null;
        }
    }
}
