using MariaBolachasProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace MariaBolachasProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoscasController : ControllerBase
    {
        private IRoscasEPaesInterface roscasEPaesService;

        public RoscasController(IRoscasEPaesInterface roscasEPaesService)
        {
            this.roscasEPaesService = roscasEPaesService;
        }

        [HttpGet]
        public ActionResult<List<RoscasEPaes>> Get()
        {
            return Ok(roscasEPaesService.ObterRoscasEPaes());
        }

        [HttpGet("{id}")]
        public ActionResult<RoscasEPaes> GetById(int id)
        {
            var roscaePaes = roscasEPaesService.ObterRoscasEPaesPorID(id);
        
            if (roscaePaes is not null)
            {
                return Ok(roscaePaes);
            }

            return NotFound($"Rosca com ID {id} não encontrada.");
        }

        [HttpPost]
        public ActionResult<RoscasEPaes> Post(int ID, RoscasEPaes novaRoscasEPaes)
        {
            roscasEPaesService.AdicionarRoscasEPaes(novaRoscasEPaes);
            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult<RoscasEPaes> Put(int ID, RoscasEPaes roscasEPaesAtualizado)
        {
            var roscasePaes = roscasEPaesService.AtualizarRoscasEPaes(ID, roscasEPaesAtualizado);
            if (roscasePaes is not null)
            {
                return Ok(roscasEPaesService.ObterRoscasEPaes());
            }

            return NotFound($"Rosca com ID {ID} não encontrado.");
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int ID)
        {
            var roscasEPaes = roscasEPaesService.RemoverRoscasEPaes(ID);
            if (roscasEPaes == true)
            {
                return Ok($"Rosca deletada com sucesso");
            }

            return NotFound($"Rosca com id: {ID} não encontrado");
        }
    }
}