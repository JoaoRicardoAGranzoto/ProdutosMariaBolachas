var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>  new[] { 
    new { Id = 1, Nome = "Sq Leite Condensado", Preco = 43.50m },
    new { Id = 2, Nome = "Semi Folhado com Goiabada", Preco = 43.50m },
    new { Id = 3, Nome = "Bolacha de Morango", Preco = 45.00m }
});




app.Run();