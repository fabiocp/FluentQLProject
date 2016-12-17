using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public abstract class FiltroDefinicao {

        public FiltroDefinicao(string nomeFiltro) {
            this.NomeFiltro = nomeFiltro;
        }

        public FiltroDefinicao(string nomeFiltro, string nomeCampo):this(nomeFiltro) {
            this.NomeCampo = nomeCampo;
        }

        public string NomeFiltro { get; private set; }

        public string NomeCampo { get; private set; }

        public string Campo {
            get {
                return string.IsNullOrEmpty(NomeCampo) ? NomeFiltro : NomeCampo;
            }
        }

    }
}
