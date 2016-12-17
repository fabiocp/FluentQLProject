using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.CoreSQL {
    public class SqlDefaultMontadorValor {

        public string MontarValor(QLExpr qlExpr) {
            if (qlExpr.Valor == null)
                return "";

            return MontarValor(qlExpr.Valor);
        }

        public string MontarValor(object valor) {
            if (valor is Array)
                return string.Join(",", (ToObjectArray(valor as Array)).Select(value => MontarValor(value)));

            if (EhBooleano(valor)) {
                return valor.ToString();
            }

            if (EhValor(valor))
                return valor.ToString().Replace(",", ".");

            if (EhData(valor))
                return ((DateTime)valor).ToString("yyyy-MM-dd");

            return valor.ToString();
        }

        public object[] ToObjectArray(Array array) {
            var objectArray = new object[array.Length];
            for (var i = 0; i < array.Length; i++) {
                objectArray[i] = array.GetValue(i); 
            }
            return objectArray;
        }


        public bool EhInteiro(object valor) {
            return new Type[]{
                typeof(int),
                typeof(int[]),
            }.Contains(valor.GetType());
        }

        public bool EhValor(object valor) {
            return new Type[]{
                typeof(decimal),
                typeof(Double),
                typeof(long),
                typeof(double),

                typeof(decimal[]),
                typeof(Double[]),
                typeof(long[]),
                typeof(double[]),
            }.Contains(valor.GetType());
        }

        public bool EhData(object valor) {
            return valor is DateTime || valor is DateTime[];
        }


        public bool EhBooleano(object valor) {
            return valor is bool;
        }

    }
}
