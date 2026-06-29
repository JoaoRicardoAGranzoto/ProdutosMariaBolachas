using MariaBolachasProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// classe que lida apenas com a API, sem se preocupar com os produtos
namespace MariaBolachasProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolachasController : ControllerBase
    {
        private IBolachasInterface bolachasService;

        public BolachasController(IBolachasInterface produtosService)
        {
            this.bolachasService = produtosService;
        }

        [HttpGet]
        public ActionResult<List<Bolachas>> Get()
        {
            return Ok(bolachasService.ObterBolachas());
        }

        [HttpGet("{nome}")]
        public ActionResult<Bolachas> GetByName(string nome)
        {
            var bolachas = bolachasService.ObterAlimentoPorNome(nome);
            if (bolachas is not null)
            {
                return Ok(bolachas);
            }
            
            return NotFound($"Alimento com nome {nome} não encontrado.");
        }

        [HttpPost]
        public ActionResult Post(Bolachas novoAlimento)
        {
            bolachasService.AdicionarBolacha(novoAlimento);
            return Created();
        }

        [HttpPut("{nome}")]
        public ActionResult Put(string nome, Bolachas alimentoAtualizado)
        {
            var bolachas = bolachasService.AtualizarBolachas(nome, alimentoAtualizado);
            if (bolachas is not null)
            {
               return Ok(bolachasService.ObterBolachas());
            }
            
            return NotFound($"Bolacha com nome {nome} não encontrado.");
        }

        [HttpDelete("{nome}")]
        public ActionResult Delete(string nome)
        {
            var bolachas = bolachasService.RemoverBolachas(nome);
            if (bolachas == true)
            {
                return Ok("Bolacha deletada com sucesso");
            }

            return NotFound($"Bolacha com nome {nome} não encontrado.");
        }
    }
}