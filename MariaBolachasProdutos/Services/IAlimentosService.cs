using System;

namespace MariaBolachasProdutos.Services;

public interface IAlimentosService
{
    public List<Alimento> ObterAlimentos();
    public Alimento ObterAlimentoPorNome(string nome);
    public void AdicionarAlimento(Alimento novoAlimento);
    public Alimento AtualizarAlimento(string nome, Alimento alimentoAtualizado);
    public bool RemoverAlimento(string nome);
}
