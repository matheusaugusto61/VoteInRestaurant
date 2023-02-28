using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.Context;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public PessoaRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PessoaDTO> RetornaPessoaPorId(long id)
        {
            var pessoas = await _context.Pessoas.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<PessoaDTO>(pessoas);
        }

        public async Task<List<PessoaDTO>> RetornaTodasAsPessoas()
        {
            var pessoas = await _context.Pessoas.ToListAsync();
            return _mapper.Map<List<PessoaDTO>>(pessoas);
        }

        public async Task<PessoaDTO> CadastraNovaPessoa(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return _mapper.Map<PessoaDTO>(pessoa);
        }
    }
}
