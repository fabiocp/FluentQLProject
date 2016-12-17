using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentQL.Core;
using FluentQL.Extensions;
using Should;

namespace FluentQL.Firebird.Tests {
    [TestClass]
    public class GeneralTests {

        [TestMethod]
        public void TestBooleano() {
            var expressao = new QLExpr("baixado", QLOperation.Igual, true);
            new SqlDefaultFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(baixado = 1)");
        }

    }
}
