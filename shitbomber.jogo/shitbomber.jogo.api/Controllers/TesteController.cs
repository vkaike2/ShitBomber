using Microsoft.AspNetCore.Mvc;
using shitbomber.jogo.domain.IServices;
using shitbomber.jogo.domain.Model;
using shitbomber.jogo.domain.Requests;
using System;
using System.Threading.Tasks;

namespace shitbomber.jogo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ITesteService _testeService;

        public TesteController(ITesteService testeService)
        {
            _testeService = testeService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeste(Guid id)
        {
            PadraoResponse<Teste> response = await _testeService.GetTeste(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTeste(Teste model)
        {
            PadraoResponse<Teste> response = await _testeService.PostTeste(model);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutTeste(Teste model)
        {
            PadraoResponse<Teste> response = await _testeService.PutTeste(model);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTeste(Guid id)
        {
            PadraoResponse<Teste> response = await _testeService.DeleteTeste(id);
            return Ok(response);
        }
    }
}