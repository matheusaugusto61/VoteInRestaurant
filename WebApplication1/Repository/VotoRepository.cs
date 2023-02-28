using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteInRestaurant.exception;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.Context;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Repository
{
    public class VotoRepository : IVotoRepository
    {
        private readonly MySqlContext _context;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IRestauranteRepository _restauranteRepository;
        private IMapper _mapper;

        public VotoRepository(MySqlContext context, IPessoaRepository pessoaRepository, IRestauranteRepository restauranteRepository, IMapper mapper)
        {
            _context = context;
            _pessoaRepository = pessoaRepository;
            _restauranteRepository = restauranteRepository;
            _mapper = mapper;
        }

        public async Task<List<RankingDTO>> RankingVotaçãoDoDia()
        {
            var votosPorRestaurante = await VotosPorRestaurantes();

            var dtoList = votosPorRestaurante
            .Select(x => new RankingDTO { Restaurante = _mapper.Map<RestauranteDTO>(x.Key), QuantidadeVotos = x.Value })
            .ToList();


            return dtoList;
        }

        public async Task<RestauranteDTO> RestauranteVencedor()
        {
            var votosPorRestaurante = await RankingVotaçãoDoDia();

            var restauranteVencedor = votosPorRestaurante
                .OrderByDescending(r => r.QuantidadeVotos)
                .FirstOrDefault();

            return restauranteVencedor.Restaurante;
        }

        public async Task<VotoDTO> VotarRestaurante(VotoDTO votoDTO)
        {
            if (!HoraValida(votoDTO.DataHora)) throw new InvalidVotingTimeException("Está fora do horario de votar");
            if (PessoaVotou(votoDTO.IdPessoa,votoDTO.DataHora)) throw new PersonHasAlreadyVotedException("Você ja votou hoje");

            var pessoa = await _pessoaRepository.RetornaPessoaPorId(votoDTO.IdPessoa);
            if (pessoa == null) throw new PersonNotFoundException("Essa pessoa não existe!");

            var restaurante = await _restauranteRepository.RetornaRestaurantePorId(votoDTO.RestauranteID);
            if (restaurante == null) throw new RestaurantNotFoundException("Esse restaurante não existe!");

            var voto = _mapper.Map<Voto>(votoDTO);
            _context.Votos.Add(voto);
            await _context.SaveChangesAsync();
            return _mapper.Map<VotoDTO>(voto);
        }

        private async Task<Dictionary<Restaurante, int>> VotosPorRestaurantes()
        {
            var votos = await _context.Votos.Include(v => v.Restaurante).ToListAsync();

            var votosPorRestaurante = votos
                .GroupBy(a => a.Restaurante)
                .Select(g => new { Restaurante = g.Key, NumeroDeVotos = g.Count() })
                .ToDictionary(x => x.Restaurante, x => x.NumeroDeVotos);

            return votosPorRestaurante;
        }

        public async Task<bool> DeletarRestaurante(long id)
        {
            try
            {
                var restaurante =
                await _context.Restaurantes.Where(r => r.Id == id)
                    .FirstOrDefaultAsync() ?? new Restaurante();
                if (restaurante == null) return false;
                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool HoraValida(DateTime dateTime)
        {
            TimeSpan noveHorasManha = new TimeSpan(9, 0, 0);
            TimeSpan onzeCinquentaManha = new TimeSpan(11, 50, 0);

            TimeSpan hora = dateTime.TimeOfDay;

            if (hora >= noveHorasManha && hora <= onzeCinquentaManha)
            {
                return true;
            }

            return false;
        }

        private bool PessoaVotou(long IdPessoa, DateTime dateTime)
        {
            var votou = _context.Votos.Any(v => v.IdPessoa == IdPessoa && v.DataHora.Day == dateTime.Day);
            return votou;

        }

        
    }
}
