using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQLProject.FluentQL {
    public class NumericoFiltroDefinicao : FiltroDefinicao {

        public NumericoFiltroDefinicao(string nomeFiltro) : base(nomeFiltro){
           
        }

        public NumericoFiltroDefinicao(string nomeFiltro, string nomeCampoSql)
             : base(nomeFiltro, nomeCampoSql){
   
        }


    }
}
