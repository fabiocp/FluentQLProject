using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQLProject.FluentQL {
    public interface IFiltroGerador {

        string Gerar(FiltroDefinicao filtroDefinicao, QLExpr qlExpr);

    }
}
