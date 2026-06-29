.using MariaBolachasProdutos.Services;
using MariaBolachasProdutos.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

//Coloca os endpoints da API no Swagger, para que seja possível testar a API através do navegador
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona a injeção de dependência para a interface IAlimentosService e a implementação ProdutosService
builder.Services.AddScoped<IBolachasInterface, BolachasServices>();
builder.Services.AddScoped<IRoscasEPaesInterface, RoscasEPaesServices>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source = Produtos.db"));

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

public class Bolachas
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}

public class RoscasEPaes
{
    public int ID { get; set; }
    public string Sabor { get; set; }
    public char Tamanho { get; set; }
    public decimal Preco { get; set; }
    public decimal Quantidade { get; set; }
}
