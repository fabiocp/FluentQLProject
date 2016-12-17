﻿using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentQL.CoreSQL {
    public class SqlDefaultNumericoFiltroGerador : IFiltroGerador {

        private readonly SqlDefaultMontadorValor montadorValor;
        public SqlDefaultNumericoFiltroGerador(SqlDefaultMontadorValor montadorValor) {
            this.montadorValor = montadorValor;
        }
        public string Gerar(QLExpr qlExpr) {

            switch (qlExpr.Operacao) {
                case QLOperation.Contem: return qlExpr.NomeFiltro + " in (" + montadorValor.MontarValor(qlExpr.Valor) + ")";
                case QLOperation.Igual: return qlExpr.NomeFiltro + " = " + montadorValor.MontarValor(qlExpr.Valor);
                case QLOperation.MaiorIgual: return qlExpr.NomeFiltro + " >= " + montadorValor.MontarValor(qlExpr.Valor);
            }

            return null;
        }
    }
}
