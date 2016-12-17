using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.Extensions {
    public static class UpdateExtensions {

        public static QLExpr Rename(this QLExpr expr, string nomeAntigo, string nomeNovo) {
            foreach (var expressao in expr.GetFiltrosPorNome(nomeAntigo)) 
                expressao.NomeFiltro = nomeNovo;
            return expr;

        }

        public static QLExpr DefinirExpressaoCustom<T>(this QLExpr expr, string nome, Func<T, string> funcRetornaExpressaoCustom) {
            foreach (var expressao in expr.GetFiltrosPorNome(nome)) {
                expressao.ExprCustomizada = funcRetornaExpressaoCustom.Invoke((T)expressao.Valor);
            }    
            return expr;

        }

        public static QLExpr DefinirExpressaoCustom(this QLExpr expr, string nome, Func<string> funcRetornaExpressaoCustom) {
            foreach (var expressao in expr.GetFiltrosPorNome(nome)) 
                expressao.ExprCustomizada = funcRetornaExpressaoCustom.Invoke();
            return expr;

        }

    }
}
