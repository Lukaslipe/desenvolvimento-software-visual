var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Funcionalidade - Requisições
// - URL | Caminho | Endereço
// - Um método HTTP

app.MapGet("/", () => "Grupo pinho");

app.MapGet("/pinho", () => "É a melhor empresa do mundo!!");

app.MapPost("/pinholog", () => "Funcionalidade do POST");

app.Run();
