using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.CoreSQL {
    public static class Extensoes {

        public static string MontarValor(this object valor) {
            if (valor == null)
                return "";

            if (valor is Array)
                return string.Join(",", ((valor as Array).ToObjectArray()).Select(value => value.ToString()));

            return valor.ToString();
        }

        public static object[] ToObjectArray(this Array array) {
            var objectArray = new object[array.Length];
            for (var i = 0; i < array.Length; i++) {
                objectArray[i] = array.GetValue(i);
                if (objectArray[i] is string) {
                    objectArray[i] = "'" + objectArray[i] + "'";
                } 
            }
            return objectArray;
        }

    }
}
