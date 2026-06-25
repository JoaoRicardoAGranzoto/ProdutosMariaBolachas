var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

//Coloca os endpoints da API no Swagger, para que seja possível testar a API através do navegador
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

var alimentos = new List<Alimentos>()
{
    new Alimentos { Id = 1, Nome = "Sequilho Leite Condensado", Preco = 43.50m, Estoque = 100 },
    new Alimentos { Id = 2, Nome = "Sequilho Creme de Leite E Limao", Preco = 43.50m, Estoque = 150 },
    new Alimentos { Id = 3, Nome = "Nata", Preco = 43.50m, Estoque = 80 },
    new Alimentos { Id = 4, Nome = "Sequilho Coco", Preco = 43.50m, Estoque = 230 },
    new Alimentos { Id = 5, Nome = "Sequilho Maracuja com Chocolate", Preco = 43.50m, Estoque = 90 },
    new Alimentos { Id = 6, Nome = "Sequilho Nata e Coco", Preco = 43.50m, Estoque = 123 },
    new Alimentos { Id = 7, Nome = "Nata com Goiabada", Preco = 43.50m, Estoque = 230 },
    new Alimentos { Id = 8, Nome = "Rosca Chocolate G", Preco = 54.50m, Estoque = 2 },
    new Alimentos { Id = 9, Nome = "Rosca Chocolate P", Preco = 38.23m, Estoque = 2 }
};

app.UseHttpsRedirection();

app.MapGet("/alimentos", () =>
{
    return alimentos;
});

app.MapGet("/alimentos/{id}", (int id) =>
{
    var alimento = alimentos.FirstOrDefault(a => a.Id == id);
    
    return alimento is not null ? Results.Ok(alimento) : Results.NotFound($"Alimento com ID {id} não encontrado.");
});

app.MapPost("/alimentos", (Alimentos novoAlimento) =>
{
    alimentos.Add(novoAlimento);
    return Results.Created();
});

app.MapPut("/alimentos/{nome}", (string nome, Alimentos alimentoAtualizado) =>
{
    var alimento = alimentos.FirstOrDefault(a => a.Nome == nome);

    if (alimento is null)
    {
        return Results.NotFound($"Alimento com nome {nome} não encontrado.");
    }

    alimento.Nome = alimentoAtualizado.Nome;
    alimento.Preco = alimentoAtualizado.Preco;
    alimento.Estoque = alimentoAtualizado.Estoque;

    return Results.Ok(alimento);
});

app.MapDelete("/alimentos/{nome}", (string nome) =>
{
    var alimento = alimentos.FirstOrDefault(a => a.Nome == nome);

    if (alimento is null)
    {
        return Results.NotFound($"Alimento com nome {nome} não encontrado.");
    }

    alimentos.Remove(alimento);
    return Results.Ok($"Alimento com nome {nome} removido com sucesso.");
});

app.Run();

class Alimentos
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}