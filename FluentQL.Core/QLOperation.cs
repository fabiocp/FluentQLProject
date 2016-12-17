using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Core {
    public enum QLOperation {

        Igual,
        Contem,
        Maior,
        MaiorIgual,
        Menor,
        MenorIgual,
        Diferente,
        ComecaCom,
        TerminaCom,
        IgualIgnoreCase,
        Entre
    }
}
