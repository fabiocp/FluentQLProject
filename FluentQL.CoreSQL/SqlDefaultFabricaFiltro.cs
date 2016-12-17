using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentQL.CoreSQL;

namespace FluentQL.CoreSQL {
    public class SqlDefaultFabricaFiltro: FabricaFiltro {

        public override IFiltroGerador GetFiltroGerador(QLExpr qlExpr) {

            var montadorValor = GetMontadorValor();

            if (montadorValor.EhInteiro(qlExpr.Valor) || montadorValor.EhValor(qlExpr.Valor)) {
                return new SqlDefaultNumericoFiltroGerador(montadorValor);
            }

            if (montadorValor.EhData(qlExpr.Valor)) {
                return new SqlDefaultDataFiltroGerador(montadorValor);
            }

            return new SqlDefaultTextoFiltroGerador(montadorValor);
        }

        protected virtual SqlDefaultMontadorValor GetMontadorValor() {
            return new SqlDefaultMontadorValor(); 
        }

        
    }
}
