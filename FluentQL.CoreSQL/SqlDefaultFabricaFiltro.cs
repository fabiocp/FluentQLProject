using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.CoreSQL {
    public class SqlDefaultFabricaFiltro: FabricaFiltro {

        public override IFiltroGerador GetFiltroGerador(FiltroDefinicao filtroDefinicao, QLExpr qlExpr) {

            if (filtroDefinicao is NumericoFiltroDefinicao) {
                return new SqlDefaultNumericoFiltroGerador();
            }

            if (filtroDefinicao is TextoFiltroDefinicao) {
                return new SqlDefaultTextoFiltroGerador();
            }

            return null;
        }
    }
}
