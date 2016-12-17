using FluentQLProject.FluentQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultTextoFiltroGerador : IFiltroGerador{
        public string Gerar(FiltroDefinicao filtroDefinicao, QLExpr qlExpr) {
            switch (qlExpr.Operacao) {
                case QLOperation.Contem: return filtroDefinicao.Campo + " like '%"+qlExpr.Valor.ToString()+"%'";
                default: return null;
            }
        }
    }
}
