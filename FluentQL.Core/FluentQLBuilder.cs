using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.Core {
    public abstract class FluentQLBuilder {

        public string Gerar(QLExpr expr) {
            return GetBuilder().Gerar(expr);
        }

        protected abstract IBuilder GetBuilder();

    }
}
