# FluentQLProject
O objetivo é desenvolver uma ferramenta que gere expressões lógicas para linguagens de consulta de bancos de dados (não apenas SQL), permitindo escrever expressões de forma simples e fluente.


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

