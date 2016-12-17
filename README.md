# FluentQLProject
Utilitário para geração de expressões lógicas. 

O objetivo é oferecer uma sintaxe fluente e simples para escrever as expressões e traduzí-las para várias linguagens de consulta diferentes. 

```c#
        [TestMethod]
        public void TestCompleto() {

            var expressao = new QLExpr("nome", QLOperation.Contem, "fab")
                .And(new QLExpr("filtrovalor", QLOperation.MaiorIgual, 5.2).Or("filtrofixo=2"))
                .And("filtroCustomizado", 1);


            expressao
                .Rename("filtrovalor", "valor")
                .DefinirExpressaoCustom<int>("filtroCustomizado", valor =>
                    "exists(select 1 from estudante e where e.idpessoa=" + valor.ToString() + ")");

            new FirebirdFluentQLBuilder()
                .Gerar(expressao)
                .ShouldEqual("(nome like '%fab%') and ((valor >= 5.2) or (filtrofixo=2)) and (exists(select 1 from estudante e where e.idpessoa=1))");

        }

}
```
