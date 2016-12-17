using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultNumericoFiltroGerador : IFiltroGerador {
        public string Gerar(FiltroDefinicao filtroDefinicao, QLExpr qlExpr) {

            switch (qlExpr.Operacao) {
                case QLOperation.Contem: {
                        if (!(qlExpr.Valor is int[])) {
                            throw new Exception("Valor deve ser um int[]");
                        }
                        var array = (int[])qlExpr.Valor;
                        return filtroDefinicao.Campo + " in (" + array.MontarValor() + ")";
                    }
                case QLOperation.Igual: return filtroDefinicao.Campo + " = " + qlExpr.Valor;
                case QLOperation.MaiorIgual: return filtroDefinicao.Campo + " >= " + qlExpr.Valor;
            }

            return null;
        }
    }
}
