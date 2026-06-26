using System;

namespace MariaBolachasProdutos.Services;

// Classe que lida apenas com produtos, sem se preocupar com a API ou o Controller
public class ProdutosService
{
    private static List<Alimento> alimentos = new List<Alimento>()
    {
        new Alimento() { Id = 1, Nome = "Sequilho Leite Condensado", Preco = 43.50m, Estoque = 100 },
        new Alimento() { Id = 2, Nome = "Sequilho Creme de Leite E Limao", Preco = 43.50m, Estoque = 150 },
        new Alimento() { Id = 3, Nome = "Nata", Preco = 43.50m, Estoque = 80 },
        new Alimento() { Id = 4, Nome = "Sequilho Coco", Preco = 43.50m, Estoque = 230 },
        new Alimento() { Id = 5, Nome = "Sequilho Maracuja com Chocolate", Preco = 43.50m, Estoque = 90 },
        new Alimento() { Id = 6, Nome = "Sequilho Nata e Coco", Preco = 43.50m, Estoque = 123 },
        new Alimento() { Id = 7, Nome = "Nata com Goiabada", Preco = 43.50m, Estoque = 230 },
        new Alimento() { Id = 8, Nome = "Rosca Chocolate G", Preco = 54.50m, Estoque = 2 },
        new Alimento() { Id = 9, Nome = "Rosca Chocolate P", Preco = 38.23m, Estoque = 2 }
    };

    public List<Alimento> ObterAlimentos()
    {
        return alimentos;
    }

    public Alimento ObterAlimentoPorNome(string nome)
    {
        return alimentos.FirstOrDefault(a => a.Nome == nome);
    }

    public void AdicionarAlimento(Alimento novoAlimento)
    {
        alimentos.Add(novoAlimento);
    }

    public Alimento AtualizarAlimento(string nome, Alimento alimentoAtualizado)
    {
        var alimento = alimentos.FirstOrDefault(a => a.Nome == nome);
        if (alimento is not null)
        {
            alimento.Nome = alimentoAtualizado.Nome;
            alimento.Preco = alimentoAtualizado.Preco;
            alimento.Estoque = alimentoAtualizado.Estoque;

            return alimento;
        }

        return null;
    }

    public bool RemoverAlimento(string nome)
    {
        var alimento = alimentos.FirstOrDefault(a => a.Nome == nome);
        if (alimento is not null)
        {
            alimentos.Remove(alimento);
            return true;
        }

        return false;
    }
}