using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private IVotoRepository _repository;

        public VotoController(IVotoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ranking")]
        public async Task<ActionResult<List<RankingDTO>>> RankingVotaçãoDoDia()
        {
            var ranking = await _repository.RankingVotaçãoDoDia();
            return Ok(ranking);
        }

        [HttpGet("restaurante-vencedor")]
        public async Task<ActionResult<RestauranteDTO>> RestauranteVencedor()
        {
            var restaurante = await _repository.RestauranteVencedor();
            return Ok(restaurante);
        }



        [HttpPost]
        public async Task<ActionResult<VotoDTO>> VotarRestaurante(VotoDTO votoDTO)
        {
            if (votoDTO == null) return BadRequest();
            var voto = await _repository.VotarRestaurante(votoDTO);
            return CreatedAtAction(nameof(VotarRestaurante), null, voto);
        }

        

    }
}
