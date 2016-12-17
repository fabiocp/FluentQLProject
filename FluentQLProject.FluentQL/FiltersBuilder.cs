using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQLProject.FluentQL {
    public class FiltersBuilder {

        public IList<FiltroDefinicao> FiltroDefinicaoList { get; private set; }

        public FiltersBuilder() {
            FiltroDefinicaoList = new List<FiltroDefinicao>();
        }

        public FiltersBuilder RegistrarFiltroNumerico(string nomeFiltro, string nomeCampoSql) {
            FiltroDefinicaoList.Add(new NumericoFiltroDefinicao(nomeFiltro, nomeCampoSql));
            return this;
        }

        public FiltersBuilder RegistrarFiltroNumerico(string nomeFiltro) {
            FiltroDefinicaoList.Add(new NumericoFiltroDefinicao(nomeFiltro));
            return this;
        }

        public FiltersBuilder RegistrarFiltroTexto(string nomeFiltro, string nomeCampoSql) {
            FiltroDefinicaoList.Add(new TextoFiltroDefinicao(nomeFiltro, nomeCampoSql));
            return this;
        }

        public FiltersBuilder RegistrarFiltroTexto(string nomeFiltro) {
            FiltroDefinicaoList.Add(new TextoFiltroDefinicao(nomeFiltro));
            return this;
        }





    }


}
