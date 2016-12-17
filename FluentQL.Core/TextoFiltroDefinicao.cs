using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public class TextoFiltroDefinicao : FiltroDefinicao {

        public TextoFiltroDefinicao(string nomeFiltro) : base(nomeFiltro){
           
        }

        public TextoFiltroDefinicao(string nomeFiltro, string nomeCampoSql)
             : base(nomeFiltro, nomeCampoSql){
   
        }


    }
}
