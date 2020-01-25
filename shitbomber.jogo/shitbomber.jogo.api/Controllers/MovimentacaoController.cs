using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shitbomber.jogo.domain.Model;

namespace shitbomber.jogo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private static List<MovimentacaoPlayer> playersList = new List<MovimentacaoPlayer>();


        [HttpGet]
        [Route("todos")]
        public IActionResult GetTodos()
        {
            VariasMovimentacoes model = new VariasMovimentacoes() { PlayersList = playersList };
            return Ok(model);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            MovimentacaoPlayer player = playersList.FirstOrDefault(e => e.Id == id);
            //if (player is null)
            //    playersList.Add(new MovimentacaoPlayer() { Id = 1 });
            return Ok(player);
        }
            
        [HttpPost]
        public IActionResult Post(MovimentacaoPlayer model)
        {
            playersList.Add(model);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(MovimentacaoPlayer model)
        {
            playersList.Remove(playersList.FirstOrDefault(e => e.Id == model.Id));
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(MovimentacaoPlayer model)
        {
            MovimentacaoPlayer player = playersList.FirstOrDefault(e => e.Id == model.Id);
            player.ValorX = model.ValorX;
            player.ValorY = model.ValorY;
            return Ok();
        }

    }
}