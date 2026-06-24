var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Primeira rota da API, que retorna uma lista de bolachas com seus respectivos preços
app.MapGet("/Bolachas", () =>  new[] { 
    new { Id = 1, Nome = "Sq Leite Condensado", Preco = 43.50m },
    new { Id = 2, Nome = "Semi Folhado com Goiabada", Preco = 43.50m },
    new { Id = 3, Nome = "Beliscao", Preco = 43.50m }




});

app.MapGet("/Roscas", () =>  new[] { 
    new { Id = 1, Nome = "Rosca de Creme P", Preco = 43.50m },
    new { Id = 2, Nome = "Rosca de Chocolate", Preco = 43.50m },
    new { Id = 3, Nome = "Rosca de Chocolate", Preco = 43.50m }
});

app.Run();