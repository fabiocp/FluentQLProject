using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentQL.Firebird;
using Should;
using System.Collections.Generic;
using FluentQL.Core;
using FluentQL.CoreSQL;

namespace FluentQL.Tests {
    [TestClass]
    public class GeneralTests {


        [TestMethod]
        public void TestComWhereAndEOr() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And("filtroidade", QLOperation.MaiorIgual, 5)
                .Or("filtroid", QLOperation.Igual, 7);

            var filterList = new FiltersBuilder()
                .RegistrarFiltroNumerico("filtroid", "id")
                .RegistrarFiltroNumerico("filtroidade", "idade")
                .RegistrarFiltroTexto("nome").FiltroDefinicaoList;
            
             new SqlBuilder(expressao, filterList, new FirebirdFabricaFiltros())
                 .Gerar()
                 .ShouldEqual("(nome like '%fab%') and (idade >= 5) or (id = 7)");

        }

        [TestMethod]
        public void TestComExpressaoInterna() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And(
                    new QLExpr("filtroidade", QLOperation.MaiorIgual, 5)
                        .Or("filtroid", QLOperation.Igual, 7));

            var filterList = new FiltersBuilder()
                .RegistrarFiltroNumerico("filtroid", "id")
                .RegistrarFiltroNumerico("filtroidade", "idade")
                .RegistrarFiltroTexto("nome").FiltroDefinicaoList;

            new SqlBuilder(expressao, filterList, new FirebirdFabricaFiltros())
                .Gerar()
                .ShouldEqual("(nome like '%fab%') and ((idade >= 5) or (id = 7))");

        }

        [TestMethod]
        public void TestComExpressaoCustomizada() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And("exists(select 1 from estudante e where e.idpessoa=p.id)");

            var filterList = new FiltersBuilder()
                .RegistrarFiltroNumerico("filtroid", "id")
                .RegistrarFiltroNumerico("filtroidade", "idade")
                .RegistrarFiltroTexto("nome").FiltroDefinicaoList;

            new SqlBuilder(expressao, filterList, new FirebirdFabricaFiltros())
                .Gerar()
                .ShouldEqual("(nome like '%fab%') and (exists(select 1 from estudante e where e.idpessoa=p.id))");

        }

        [TestMethod]
        public void Test2Customizadas() {

            var expressao = new QLExpr("exists(select 1 from estudante e where e.idpessoa=p.id)")
                .And("exists(select 1 from estudante e where e.idpessoa=p.id)");

            var filterList = new FiltersBuilder()
                .RegistrarFiltroNumerico("filtroid", "id")
                .RegistrarFiltroNumerico("filtroidade", "idade")
                .RegistrarFiltroTexto("nome").FiltroDefinicaoList;

            new SqlBuilder(expressao, filterList, new FirebirdFabricaFiltros())
                .Gerar()
                .ShouldEqual("(exists(select 1 from estudante e where e.idpessoa=p.id)) and (exists(select 1 from estudante e where e.idpessoa=p.id))");

        }

        [TestMethod]
        public void Test2Internas() {

            var expressao = new QLExpr(new QLExpr("nome", QLOperation.Contem, "fab"))
                .And(new QLExpr("nome", QLOperation.Contem, "fab"));

            var filterList = new FiltersBuilder()
                .RegistrarFiltroNumerico("filtroid", "id")
                .RegistrarFiltroNumerico("filtroidade", "idade")
                .RegistrarFiltroTexto("nome").FiltroDefinicaoList;

            new SqlBuilder(expressao, filterList, new FirebirdFabricaFiltros())
                .Gerar()
                .ShouldEqual("((nome like '%fab%')) and ((nome like '%fab%'))");

        }
    }
}
