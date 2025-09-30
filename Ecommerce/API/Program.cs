using API.models;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos fake

List<Produto> produtos = new List<Produto>
      {
           new Produto { Nome = "Notebook Dell", Quantidade = 10, Preco = 3500.00 },
           new Produto { Nome = "Smartphone Samsung", Quantidade = 20, Preco = 2200.00 },
           new Produto { Nome = "Mouse Gamer", Quantidade = 50, Preco = 150.00 },
           new Produto { Nome = "Teclado Mecânico", Quantidade = 30, Preco = 300.00 },
           new Produto { Nome = "Monitor LG 24\"", Quantidade = 15, Preco = 900.00 },
           new Produto { Nome = "Cadeira Gamer", Quantidade = 8, Preco = 1200.00 },
           new Produto { Nome = "Headset HyperX", Quantidade = 25, Preco = 350.00 },
           new Produto { Nome = "Impressora HP", Quantidade = 5, Preco = 700.00 },
           new Produto { Nome = "HD Externo 1TB", Quantidade = 40, Preco = 400.00 },
           new Produto { Nome = "Pen Drive 64GB", Quantidade = 100, Preco = 80.00 }
       };


            //Funcionalidade - Requisições
            // - URL/caminho/endereço
            // - um método HTTP

app.MapGet("/", () => "API de produtos");

//GET:/api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Any())
    {
        return Results.Ok (produtos);
    }

    return Results.NotFound("Lista vazia!");
});

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}", (string nome) =>
{
    //expressão lambda
    Produto? resultado = produtos.FirstOrDefault(x => x.Nome == nome);
    if (resultado == null)
    {
    return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(resultado);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{

    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado!");
        }
    }

    produtos.Add(produto);
    return Results.Created("", produto);

});

app.MapDelete("/api/produto/remover/{id}", ([FromRoute]string id) =>
{
    //expressão lambda
    Produto? resultado = produtos.FirstOrDefault(x => x.Id == id);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    produtos.Remove(resultado);
    return Results.Ok("Produto removido com sucesso!");
}); 

// PUT: /api/produto/editar/{id}
app.MapPatch("/api/produto/editar/{id}", (string id, [FromBody] Produto produtoEditado) =>
{
    Produto? produtoExistente = produtos.FirstOrDefault(p => p.Id == id);

    if (produtoExistente == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    produtoExistente.Nome = produtoEditado.Nome;
    produtoExistente.Quantidade = produtoEditado.Quantidade;
    produtoExistente.Preco = produtoEditado.Preco;

    return Results.Ok(produtoExistente);
});

app.Run();