using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepository _repository;

        public PessoaController(IPessoaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PessoaDTO>>> RetornaPessoaPorId(long id)
        {
            var restaurants = await _repository.RetornaPessoaPorId(id);
            return Ok(restaurants);
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaDTO>>> RetornaTodasAsPessoas()
        {
            var restaurants = await _repository.RetornaTodasAsPessoas();
            return Ok(restaurants);
        }

        
        [HttpPost]
        public async Task<ActionResult<List<PessoaDTO>>> CadastraNovaPessoa(PessoaDTO pessoaDTO)
        {
            if (pessoaDTO == null) return BadRequest();
            var pessoa = await _repository.CadastraNovaPessoa(pessoaDTO);
            return CreatedAtAction(nameof(CadastraNovaPessoa), null, pessoa);
        }



       
    }
}
