﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.Core {
    public interface IBuilder {

        string Gerar(QLExpr expr);
    }
}
