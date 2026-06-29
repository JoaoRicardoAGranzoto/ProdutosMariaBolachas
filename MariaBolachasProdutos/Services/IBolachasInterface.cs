using System;

namespace MariaBolachasProdutos.Services;

public interface IBolachasInterface
{
    public List<Bolachas> ObterBolachas();
    public Bolachas ObterAlimentoPorNome(string nome);
    public void AdicionarBolacha(Bolachas novoAlimento);
    public Bolachas AtualizarBolachas(string nome, Bolachas alimentoAtualizado);
    public bool RemoverBolachas(string nome);
}