using System;

namespace MariaBolachasProdutos.Services;

public interface IRoscasEPaesInterface
{
    public List<RoscasEPaes> ObterRoscasEPaes();
    public RoscasEPaes ObterRoscasEPaesPorID(int ID);
    public void AdicionarRoscasEPaes(RoscasEPaes novaRosca);
    public RoscasEPaes AtualizarRoscasEPaes(int ID, RoscasEPaes roscaAtualizada);
    public bool RemoverRoscasEPaes(int ID);
}