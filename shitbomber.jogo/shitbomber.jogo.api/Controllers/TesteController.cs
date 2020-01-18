using Microsoft.AspNetCore.Mvc;
using shitbomber.jogo.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shitbomber.jogo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        public static List<Teste> tabelaTeste = new List<Teste>();

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeste(Guid id)
        {
            Teste modelCadastrado = tabelaTeste.FirstOrDefault(e => e.Id == id);
            return Ok(modelCadastrado);
        }

        [HttpPost]
        public async Task<IActionResult> PostTeste(Teste model)
        {
            model.Id = Guid.NewGuid();
            tabelaTeste.Add(model);
            return Ok(model);
        }

        [HttpPut]
        public async Task<IActionResult> PutTeste(Teste model)
        {
            if (model.Id == Guid.Empty) return BadRequest("O CAMPO Id é obrigatório!");

            Teste modelCadastrado = tabelaTeste.FirstOrDefault(e => e.Id == model.Id);

            if (modelCadastrado is null) return BadRequest("Manda o Id certo bobão!");

            modelCadastrado.Nome = model.Nome;

            return Ok(modelCadastrado);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTeste(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("O CAMPO Id é obrigatório!");

            Teste modelCadastrado = tabelaTeste.FirstOrDefault(e => e.Id == id);
            tabelaTeste.Remove(modelCadastrado);

            return Ok("Xablau deletado!");
        }
    }
}