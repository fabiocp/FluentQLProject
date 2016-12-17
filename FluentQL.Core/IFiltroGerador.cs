using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public interface IFiltroGerador {

        string Gerar(FiltroDefinicao filtroDefinicao, QLExpr qlExpr);

    }
}
