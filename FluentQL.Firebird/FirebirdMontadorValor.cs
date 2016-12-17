using FluentQL.CoreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.Firebird {
    public class FirebirdMontadorValor : SqlDefaultMontadorValor{

        public override string MontarValor(object valor) {
            if (valor is bool)
                return (bool)valor ? "1" : "0";
            else
                return base.MontarValor(valor);
        }
    }
}
