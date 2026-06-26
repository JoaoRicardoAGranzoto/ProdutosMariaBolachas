using MariaBolachasProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// classe que lida apenas com a API, sem se preocupar com os produtos
namespace MariaBolachasProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private ProdutosService produtosService= new ProdutosService();

        [HttpGet]
        public ActionResult<List<Alimento>> Get()
        {
            return Ok(produtosService.ObterAlimentos());
        }

        [HttpGet("{nome}")]
        public ActionResult<Alimento> GetByName(string nome)
        {
            var alimento = produtosService.ObterAlimentoPorNome(nome);
            if (alimento is not null)
            {
                return Ok(alimento);
            }
            
            return NotFound($"Alimento com nome {nome} não encontrado.");
        }

        [HttpPost]
        public ActionResult Post(Alimento novoAlimento)
        {
            produtosService.AdicionarAlimento(novoAlimento);
            return Created();
        }

        [HttpPut("{nome}")]
        public ActionResult Put(string nome, Alimento alimentoAtualizado)
        {
            var alimento = produtosService.AtualizarAlimento(nome, alimentoAtualizado);
            if (alimento is not null)
            {
               return Ok(produtosService.ObterAlimentos());
            }
            
            return NotFound($"Alimento com nome {nome} não encontrado.");
        }

        [HttpDelete("{nome}")]
        public ActionResult Delete(string nome)
        {
            var alimento = produtosService.RemoverAlimento(nome);
            if (alimento == true)
            {
                return NoContent();
            }

            return NotFound($"Alimento com nome {nome} não encontrado.");
        }
    }
}