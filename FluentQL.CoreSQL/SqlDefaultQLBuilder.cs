﻿using FluentQL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentQL.CoreSQL {
    public class SqlDefaultFluentQLBuilder : FluentQLBuilder {
        protected override IBuilder GetBuilder() {
            return new SqlBuilder(new SqlDefaultFabricaFiltro());
        }
    }
}
