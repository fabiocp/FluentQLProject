using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public abstract class FabricaFiltro {

        public string Gerar(FiltroDefinicao filtroDefinicao, QLExpr qlExpr){
            return GetFiltroGerador(filtroDefinicao, qlExpr).Gerar(filtroDefinicao, qlExpr);
        }

        public abstract IFiltroGerador GetFiltroGerador(FiltroDefinicao filtroDefinicao, QLExpr qlExpr);

    }
}
