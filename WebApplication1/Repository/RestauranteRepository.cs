using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.Context;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Repository.Interface;

namespace VoteInRestaurant.Repository
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public RestauranteRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RestauranteDTO> RetornaRestaurantePorId(long id)
        {
            var restaurants = await _context.Restaurantes.Where(r => r.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<RestauranteDTO>(restaurants);
        }

        public async Task<List<RestauranteDTO>> RetornaTodosRestaurantes()
        {
            var restaurants = await _context.Restaurantes.ToListAsync();
            return _mapper.Map<List<RestauranteDTO>>(restaurants);
        }

        public async Task<RestauranteDTO> CadastraRestaurante(RestauranteDTO restaurantDTO)
        {
            var restaurant = _mapper.Map<Restaurante>(restaurantDTO);
            _context.Restaurantes.Add(restaurant);
            await _context.SaveChangesAsync();
            return _mapper.Map<RestauranteDTO>(restaurant);
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


    }
}
