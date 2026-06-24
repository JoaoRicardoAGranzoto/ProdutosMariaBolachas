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

var bolachas = new List<Bolachas>()
{
    new Bolachas { Id = 1, Nome = "Sequilho Leite Condensado", Preco = 43.50m, Estoque = 100 },
    new Bolachas { Id = 2, Nome = "Sequilho Creme de Leite E Limao", Preco = 43.50m, Estoque = 150 },
    new Bolachas { Id = 3, Nome = "Nata", Preco = 43.50m, Estoque = 80 },
    new Bolachas { Id = 4, Nome = "Sequilho Coco", Preco = 43.50m, Estoque = 230 },
    new Bolachas { Id = 5, Nome = "Sequilho Maracuja com Chocolate", Preco = 43.50m, Estoque = 90 },
    new Bolachas { Id = 6, Nome = "Sequilho Nata e Coco", Preco = 43.50m, Estoque = 123 },
    new Bolachas { Id = 7, Nome = "Nata com Goiabada", Preco = 43.50m, Estoque = 230 },
};

app.UseHttpsRedirection();

//Primeira rota da API, que retorna uma lista de bolachas com seus respectivos preços
app.MapGet("/Bolachas", () => bolachas);

app.MapGet("/Bolachas/{Nome}", (string nome) =>
{
    var bolacha = bolachas.First(b => b.Nome == nome);
    if (bolacha == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(bolacha);
});

app.MapPost("/Bolachas", (Bolachas bolacha) =>
{
    bolachas.Add(bolacha);
    return Results.Created($"/Bolachas/{bolacha.Nome}", bolacha);
});

app.MapPut("/Bolachas/{Nome}", (string nome, Bolachas bolachaAtualizada) =>
{
    var bolacha = bolachas.FirstOrDefault(b => b.Nome == nome);
    if (bolacha == null)
    {
        return Results.NotFound();
    }
    bolacha.Nome = bolachaAtualizada.Nome;
    bolacha.Preco = bolachaAtualizada.Preco;
    bolacha.Estoque = bolachaAtualizada.Estoque;
    return Results.Ok(bolacha);
});

app.Run();

class Bolachas
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}