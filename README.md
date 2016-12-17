# FluentQLProject
Utilitário para geração de expressões lógicas para linguagens de consulta. 
O objetivo é oferecer uma sintaxe fluente e simples para escrever as expressões e traduzí-las para várias linguagens de consulta diferentes. 

```c#
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
```
