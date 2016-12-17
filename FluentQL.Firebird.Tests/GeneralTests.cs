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


        [TestMethod]
        public void TestCompleto() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And(new QLExpr("filtrovalor", QLOperation.MaiorIgual, 5.2).Or("filtrofixo=2"))
                .And("filtroCustomizado", 1);


            expressao
                .Rename("filtrovalor", "valor")
                .DefinirExpressaoCustom<int>("filtroCustomizado", valor =>
                    "exists(select 1 from estudante e where e.idpessoa=" + valor.ToString() + ")");

            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and ((valor >= 5.2) or (filtrofixo=2)) and (exists(select 1 from estudante e where e.idpessoa=1))");

        }


        [TestMethod]
        public void TestData() {
            var expressao = new QLExpr("data", QLOperation.Menor, DateTime.ParseExact("14/06/2019", "dd/MM/yyyy", null));
            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(data < '2019-06-14')");
        }


        [TestMethod]
        public void TestDataEntre() {
            var expressao = new QLExpr("data", QLOperation.Entre, new DateTime[] { DateTime.ParseExact("14/06/2019", "dd/MM/yyyy", null), DateTime.ParseExact("15/06/2019", "dd/MM/yyyy", null) });
            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(data >= '2019-06-14' and data < '2019-06-16')");
        }


        [TestMethod]
        public void TestBooleano() {
            var expressao = new QLExpr("baixado", QLOperation.Igual, true);
            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(baixado = 1)");
        }

        [TestMethod]
        public void TestInteiroEntre() {
            var expressao = new QLExpr("id", QLOperation.Entre, new int[]{1,2,3});
            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(id in (1,2,3))");
        }

        [TestMethod]
        public void TestValorEntre() {
            var expressao = new QLExpr("id", QLOperation.Entre, new Double[] { 1.1, 2.2, 3.1 });
            new FirebirdFluentQLBuilder().Gerar(expressao)
                .ShouldEqual("(id in (1.1,2.2,3.1))");
        }

    }
}
