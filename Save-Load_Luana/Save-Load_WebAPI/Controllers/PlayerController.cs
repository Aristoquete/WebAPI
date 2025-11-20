using Save_Load_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Save_Load_WebAPI.Controllers
{
    public class PlayerController : ControllerBase
    {
        public static List<Player> players = new()
        {
            new Player { Id = "1", Vida = 10, QuantidadeItens = 0, PosicaoX = 0, PosicaoY = 0, PosicaoZ = 0 },
        };

        [HttpGet]
        [Route("api/Player")]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("api/Player/{id}")]
        //Faz com que identifique o Player e pegue todas as suas informações apenas usando o ID
        public IActionResult GetPlayerByID(string id)
        {
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("api/Player")]
        //Adiciona um player novo na lista
        public IActionResult AddPlayer([FromBody] Player newPlayer)
        {
            players.Add(newPlayer);
            return Ok(newPlayer);
        }

        [HttpDelete]
        [Route("api/Player/{id}")]
        //Deleta o Player com base do seu ID
        public IActionResult DeletePlayer(string id)
        {
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            players.Remove(player);
            return Ok();
        }
        [HttpPut]
        [Route("api/Player/{id}")]
        //Atualiza as informações do Player
        public IActionResult UpdatePlayer(string id, [FromBody] Player playerAtt)
        {
            var player = players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Vida = playerAtt.Vida;
            player.QuantidadeItens = playerAtt.QuantidadeItens;
            player.PosicaoX = playerAtt.PosicaoX;
            player.PosicaoY = playerAtt.PosicaoY;
            player.PosicaoZ = playerAtt.PosicaoZ;

            return Ok(player);
        }
    }
}
