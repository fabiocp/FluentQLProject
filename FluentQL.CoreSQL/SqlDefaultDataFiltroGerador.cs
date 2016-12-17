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
                case QLOperation.Igual: return montadorValor.MontarExpressaoPadrao(qlExpr, "=", "'{valor}'");
                case QLOperation.MaiorIgual: return montadorValor.MontarExpressaoPadrao(qlExpr, ">=", "'{valor}'");
                case QLOperation.Maior: return montadorValor.MontarExpressaoPadrao(qlExpr, ">", "'{valor}'");
                case QLOperation.MenorIgual: return montadorValor.MontarExpressaoPadrao(qlExpr, "<=", "'{valor}'");
                case QLOperation.Menor: return montadorValor.MontarExpressaoPadrao(qlExpr, "<", "'{valor}'");
                case QLOperation.Entre:{ 
                    var datas = (DateTime[]) qlExpr.Valor;
                    return qlExpr.NomeFiltro + " >= " + "'"+datas[0].ToString("yyyy-MM-dd")+"' and "+qlExpr.NomeFiltro + " < " + "'"+datas[1].AddDays(1).ToString("yyyy-MM-dd") + "'";
                }
            }

            return null;
        }
    }
}
