using Microsoft.AspNetCore.Mvc;
using VoteInRestaurant.Model.DTO;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.DTO;

namespace VoteInRestaurant.Repository.Interface
{
    public interface IVotoRepository
    {
        Task<List<RankingDTO>> RankingVotaçãoDoDia();
        Task<VotoDTO> VotarRestaurante(VotoDTO votoDTO);
        Task<RestauranteDTO> RestauranteVencedor();
    }
}
