using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentQL.Core;
using FluentQL.Extensions;
using Should;

namespace FluentQL.Firebird.Tests {
    [TestClass]
    public class GeneralTests {


        [TestMethod]
        public void TestComWhereAndEOr() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And("filtroidade", QLOperation.MaiorIgual, 5)
                .Or("filtroid", QLOperation.Igual, 7);

            expressao
                .Rename("filtroidade", "idade")
                .Rename("filtroid", "id");

            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and (idade >= 5) or (id = 7)");

        }

        [TestMethod]
        public void TestComExpressaoInterna() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And(
                    new QLExpr("filtroidade", QLOperation.MaiorIgual, 5)
                        .Or("filtroid", QLOperation.Igual, 7));

            expressao
                .Rename("filtroidade", "idade")
                .Rename("filtroid", "id");

            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and ((idade >= 5) or (id = 7))");

        }

        [TestMethod]
        public void TestComExpressaoCustomizada() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And("exists(select 1 from estudante e where e.idpessoa=p.id)");


            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and (exists(select 1 from estudante e where e.idpessoa=p.id))");

        }

        [TestMethod]
        public void Test2Customizadas() {

            var expressao = new QLExpr("exists(select 1 from estudante e where e.idpessoa=p.id)")
                .And("exists(select 1 from estudante e where e.idpessoa=p.id)");


            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(exists(select 1 from estudante e where e.idpessoa=p.id)) and (exists(select 1 from estudante e where e.idpessoa=p.id))");

        }

        [TestMethod]
        public void Test2Internas() {

            var expressao = new QLExpr(new QLExpr("filtronome", QLOperation.Contem, "fab"))
                .And(new QLExpr("nome2", QLOperation.Contem, "fab"));

            expressao.Rename("filtronome", "nome");

            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("((nome like '%fab%')) and ((nome2 like '%fab%'))");

        }


        [TestMethod]
        public void TestComExpressaoCustomizadaNova() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And("filtrovalor", QLOperation.MaiorIgual, 5.2)
                .And("filtroCustomizado", 1);


            expressao
                .Rename("filtrovalor", "valor")
                .DefinirExpressaoCustom<int>("filtroCustomizado", valor =>
                    "exists(select 1 from estudante e where e.idpessoa=" + valor.ToString() + ")");

            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and (valor >= 5.2) and (exists(select 1 from estudante e where e.idpessoa=1))");

        }


    }
}
