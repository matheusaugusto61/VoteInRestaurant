using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.DTO;

namespace VoteInRestaurant.Repository.Interface
{
    public interface IRestauranteRepository
    {
        Task<RestauranteDTO> RetornaRestaurantePorId(long id);
        Task<List<RestauranteDTO>> RetornaTodosRestaurantes();
        Task<RestauranteDTO> CadastraRestaurante(RestauranteDTO restaurantDTO);
        Task<bool> DeletarRestaurante(long id);
    }
}
