using FluentQL.CoreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.Firebird {
    public class FirebirdFabricaFiltros : SqlDefaultFabricaFiltro{

        protected override SqlDefaultMontadorValor GetMontadorValor() {
            return new FirebirdMontadorValor();
        }

    }
}
