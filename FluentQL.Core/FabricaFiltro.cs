using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public abstract class FabricaFiltro {

        public string Gerar(QLExpr qlExpr){
            return GetFiltroGerador(qlExpr).Gerar(qlExpr);
        }

        public abstract IFiltroGerador GetFiltroGerador(QLExpr qlExpr);

         

    }
}
