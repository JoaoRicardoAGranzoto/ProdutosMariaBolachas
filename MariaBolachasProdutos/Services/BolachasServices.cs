using System;

namespace MariaBolachasProdutos.Services;

// Classe que lida apenas com produtos, sem se preocupar com a API ou o Controller
public class BolachasServices : IBolachasInterface
{
    private static List<Bolachas> bolachas = new List<Bolachas>()
    {
        new Bolachas() { Id = 1, Nome = "Sequilho Leite Condensado", Preco = 43.50m, Estoque = 100 },
        new Bolachas() { Id = 2, Nome = "Sequilho Creme de Leite E Limao", Preco = 43.50m, Estoque = 150 },
        new Bolachas() { Id = 3, Nome = "Nata", Preco = 43.50m, Estoque = 80 },
        new Bolachas() { Id = 4, Nome = "Sequilho Coco", Preco = 43.50m, Estoque = 230 },
        new Bolachas() { Id = 5, Nome = "Sequilho Maracuja com Chocolate", Preco = 43.50m, Estoque = 90 },
        new Bolachas() { Id = 6, Nome = "Sequilho Nata e Coco", Preco = 43.50m, Estoque = 123 },
        new Bolachas() { Id = 7, Nome = "Nata com Goiabada", Preco = 43.50m, Estoque = 230 },
    };

    public List<Bolachas> ObterBolachas()
    {
        return bolachas;
    }

    public Bolachas ObterAlimentoPorNome(string nome)
    {
        return bolachas.FirstOrDefault(a => a.Nome == nome);
    }

    public void AdicionarBolacha(Bolachas novoAlimento)
    {
        bolachas.Add(novoAlimento);
    }

    public Bolachas AtualizarBolachas(string nome, Bolachas alimentoAtualizado)
    {
        var alimento = bolachas.FirstOrDefault(a => a.Nome == nome);
        if (alimento is not null)
        {
            alimento.Nome = alimentoAtualizado.Nome;
            alimento.Preco = alimentoAtualizado.Preco;
            alimento.Estoque = alimentoAtualizado.Estoque;

            return alimento;
        }

        return null;
    }

    public bool RemoverBolachas(string nome)
    {
        var alimento = bolachas.FirstOrDefault(a => a.Nome == nome);
        if (alimento is not null)
        {
            bolachas.Remove(alimento);
            return true;
        }

        return false;
    }
}