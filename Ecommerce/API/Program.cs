using System.Runtime.InteropServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(
    options => options.AddPolicy("Acesso Total",
    configs => configs
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
);

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
app.MapGet("/api/produto/listar",
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    } 

    return Results.NotFound("Lista vazia!");
});

//GET: /api/produto/buscar/nome_do_produto
app.MapGet("/api/produto/buscar/{nome}",
    ([FromRoute]string nome,
    [FromServices] AppDataContext ctx) =>
{
    //expressão lambda
    Produto? resultado = ctx.Produtos.FirstOrDefault(x => x.Nome == nome);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }
    return Results.Ok(resultado);
});

//POST: /api/produto/cadastrar
app.MapPost("/api/produto/cadastrar",
    ([FromBody] Produto produto,
    [FromServices] AppDataContext ctx) =>
{

    Produto? resultado =
        ctx.Produtos.FirstOrDefault(x => x.Nome == produto.Nome);
    if (resultado is null)
    {
        ctx.Produtos.Add(produto);
        ctx.SaveChanges();
        return Results.Created("", produto);
    }
    else
    {
        return Results.Conflict("Esse produto já existe!");
    }

});

app.MapDelete("/api/produto/remover/{id}",
    ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Produto? resultado = ctx.Produtos.Find(id);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    ctx.Produtos.Remove(resultado);
    ctx.SaveChanges();
    return Results.Ok("Produto removido com sucesso!");
}); 

// PUT: /api/produto/editar/{id}
app.MapPatch("/api/produto/editar/{id}",
    ([FromRoute] string id,
    [FromBody] Produto produtoEditado,
    [FromServices] AppDataContext ctx) =>
{
    Produto? produtoExistente = ctx.Produtos.Find(id);

    if (produtoExistente == null)
    {
        return Results.NotFound("Produto não encontrado!");
    }

    produtoExistente.Nome = produtoEditado.Nome;
    produtoExistente.Quantidade = produtoEditado.Quantidade;
    produtoExistente.Preco = produtoEditado.Preco;

    ctx.Produtos.Update(produtoExistente);
    ctx.SaveChanges();
    return Results.Ok(produtoExistente);
});

app.UseCors("Acesso Total");

app.Run();