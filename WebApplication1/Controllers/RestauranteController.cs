using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private IRestauranteRepository _repository;

        public RestauranteController(IRestauranteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestauranteDTO>> RetornaRestaurantePorId(long id)
        {
            var restaurants = await _repository.RetornaRestaurantePorId(id);
            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<ActionResult<List<RestauranteDTO>>> RetornaTodosRestaurantes()
        {
            var restaurants = await _repository.RetornaTodosRestaurantes();
            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<ActionResult<List<RestauranteDTO>>> CadastraRestaurante(RestauranteDTO restaurantDTO)
        {
            if (restaurantDTO == null) return BadRequest();
            var restaurant = await _repository.CadastraRestaurante(restaurantDTO);
            return CreatedAtAction(nameof(CadastraRestaurante), null, restaurant);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarRestaurante(long id)
        {
            var status = await _repository.DeletarRestaurante(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
