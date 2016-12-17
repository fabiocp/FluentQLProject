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
                case QLOperation.Contem: return qlExpr.NomeFiltro + " like '%" + qlExpr.Valor.ToString() + "%'";
                default: return null;
            }
        }
    }
}
