using API.models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Lista de produtos fake

List<Produto> produtos = new List<Produto>
      {
           new Produto { Nome = "Notebook Dell", Quntidade = 10, Preco = 3500.00 },
           new Produto { Nome = "Smartphone Samsung", Quntidade = 20, Preco = 2200.00 },
           new Produto { Nome = "Mouse Gamer", Quntidade = 50, Preco = 150.00 },
           new Produto { Nome = "Teclado Mecânico", Quntidade = 30, Preco = 300.00 },
           new Produto { Nome = "Monitor LG 24\"", Quntidade = 15, Preco = 900.00 },
           new Produto { Nome = "Cadeira Gamer", Quntidade = 8, Preco = 1200.00 },
           new Produto { Nome = "Headset HyperX", Quntidade = 25, Preco = 350.00 },
           new Produto { Nome = "Impressora HP", Quntidade = 5, Preco = 700.00 },
           new Produto { Nome = "HD Externo 1TB", Quntidade = 40, Preco = 400.00 },
           new Produto { Nome = "Pen Drive 64GB", Quntidade = 100, Preco = 80.00 }
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
     //     foreach (Produto produtoCadastrado in produtos)
     //     {
     //         if (produtoCadastrado.Nome == nome)
     //         {
     //             return Results.Ok(produtoCadastrado);
     //         }
     //     }
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

//  {
//     if (produtos.Any(p => p.Nome.Equals(produto.Nome, StringComparison.OrdinalIgnoreCase)))
//     {
//         return Results.BadRequest(new
//         {
//             sucesso = false,
//             mensagem = "Já existe um produto cadastrado com esse nome."
//         });
//     }

//     produtos.Add(produto);

//     return Results.Ok(produtos);
// });

//proxima aula implementar a remoção e atualização do produto 

app.Run();