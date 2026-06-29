
namespace MariaBolachasProdutos.Services
{
    public class RoscasEPaesServices : IRoscasEPaesInterface
    {
        private List<RoscasEPaes> roscasEPaes = new List<RoscasEPaes>()
        {
            new RoscasEPaes() { ID = 1, Sabor = "Rosca Chocolate", Tamanho = 'G', Preco = 54.50m, Quantidade = 2 },
            new RoscasEPaes() { ID = 2, Sabor = "Rosca Chocolate", Tamanho = 'P', Preco = 38.23m, Quantidade = 1 },
            new RoscasEPaes() { ID = 3, Sabor = "Rosca Doce de Leite e Nozes", Tamanho = 'G', Preco = 54.50m, Quantidade = 2 },
            new RoscasEPaes() { ID = 4, Sabor = "Rosca Doce de Leite e Nozes", Tamanho = 'P', Preco = 38.23m, Quantidade = 1 },
            new RoscasEPaes() { ID = 5, Sabor = "Rosca Romeu e Julieta", Tamanho = 'P', Preco = 38.23m, Quantidade = 1 },
            new RoscasEPaes() { ID = 6, Sabor = "Rosca Chocolate e Avela", Tamanho = 'P', Preco = 42, Quantidade = 2 },
            new RoscasEPaes() { ID = 7, Sabor = "Rosca Chocolate Preto e Branco", Tamanho = 'G', Preco = 60.00m, Quantidade = 1 },
            new RoscasEPaes() { ID = 8, Sabor = "Rosca Chocolate Preto e Branco", Tamanho = 'P', Preco = 42.00m, Quantidade = 1 },
            new RoscasEPaes() { ID = 9, Sabor = "Rosca Tradicional", Tamanho = 'G', Preco = 39.60m, Quantidade = 3 },
            new RoscasEPaes() { ID = 10, Sabor = "Rosca Tradicional", Tamanho = 'P', Preco = 27.70m, Quantidade = 3 },
            new RoscasEPaes() { ID = 11, Sabor = "Pão Caseiro", Tamanho = 'G', Preco = 23.00m, Quantidade = 6 },
            new RoscasEPaes() { ID = 12, Sabor = "Pão Caseiro", Tamanho = 'P', Preco = 16.00m, Quantidade = 6 },
        };

        public List<RoscasEPaes> ObterRoscasEPaes()
        {
            return roscasEPaes;
        }

        public RoscasEPaes ObterRoscasEPaesPorID(int ID)
        {
            return roscasEPaes.FirstOrDefault(rosca => rosca.ID == ID);
        }

        public void AdicionarRoscasEPaes(RoscasEPaes novaRoscasEPaes)
        {
            roscasEPaes.Add(novaRoscasEPaes);
        }

        public RoscasEPaes AtualizarRoscasEPaes(int ID, RoscasEPaes roscasEPaesAtualizadas)
        {
            var roscasEPaes = this.roscasEPaes.FirstOrDefault(r => r.ID == ID);
            if (roscasEPaes is not null)
            {
                roscasEPaes.Sabor = roscasEPaesAtualizadas.Sabor;
                roscasEPaes.Tamanho = roscasEPaesAtualizadas.Tamanho;
                roscasEPaes.Preco = roscasEPaesAtualizadas.Preco;
                roscasEPaes.Quantidade = roscasEPaesAtualizadas.Quantidade;
                return roscasEPaes;
            }
            return null;
        }

        public bool RemoverRoscasEPaes(int ID)
        {
            var roscaEPao = roscasEPaes.FirstOrDefault(r => r.ID == ID);
            if (roscaEPao is not null)
            {
                roscasEPaes.Remove(roscaEPao);
                return true;
            }
            return false;
        }
    }
}