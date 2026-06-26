using MariaBolachasProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

//Coloca os endpoints da API no Swagger, para que seja possível testar a API através do navegador
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a injeção de dependência para a interface IAlimentosService e a implementação ProdutosService
builder.Services.AddScoped<IAlimentosService, ProdutosService>();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Alimento> Alimentos = new List<Alimento>()
{
    new Alimento { Id = 1, Nome = "Sequilho Leite Condensado", Preco = 43.50m, Estoque = 100 },
    new Alimento { Id = 2, Nome = "Sequilho Creme de Leite E Limao", Preco = 43.50m, Estoque = 150 },
    new Alimento { Id = 3, Nome = "Nata", Preco = 43.50m, Estoque = 80 },
    new Alimento { Id = 4, Nome = "Sequilho Coco", Preco = 43.50m, Estoque = 230 },
    new Alimento { Id = 5, Nome = "Sequilho Maracuja com Chocolate", Preco = 43.50m, Estoque = 90 },
    new Alimento { Id = 6, Nome = "Sequilho Nata e Coco", Preco = 43.50m, Estoque = 123 },
    new Alimento { Id = 7, Nome = "Nata com Goiabada", Preco = 43.50m, Estoque = 230 },
    new Alimento { Id = 8, Nome = "Rosca Chocolate G", Preco = 54.50m, Estoque = 2 },
    new Alimento { Id = 9, Nome = "Rosca Chocolate P", Preco = 38.23m, Estoque = 2 }
    };

app.MapGet("/alimentos", () =>
{
    return Alimentos;
});

app.MapGet("/alimentos/{id}", (int id) =>
{
    var alimento = Alimentos.FirstOrDefault(a => a.Id == id);
    
    return alimento is not null ? Results.Ok(alimento) : Results.NotFound($"Alimento com ID {id} não encontrado.");
});

app.MapPost("/alimentos", (Alimento novoAlimento) =>
{
    Alimentos.Add(novoAlimento);
    return Results.Created();
});

app.MapPut("/alimentos/{nome}", (string nome, Alimento alimentoAtualizado) =>
{
    var alimento = Alimentos.FirstOrDefault(a => a.Nome == nome);

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
    var alimento = Alimentos.FirstOrDefault(a => a.Nome == nome);

    if (alimento is null)
    {
        return Results.NotFound($"Alimento com nome {nome} não encontrado.");
    }

    Alimentos.Remove(alimento);
    return Results.Ok($"Alimento com nome {nome} removido com sucesso.");
});

app.Run();

public class Alimento
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}