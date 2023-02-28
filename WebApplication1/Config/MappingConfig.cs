using AutoMapper;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.DTO;

namespace VoteInRestaurant.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RestauranteDTO, Restaurante>();
                config.CreateMap<Restaurante, RestauranteDTO>();

                config.CreateMap<PessoaDTO, Pessoa>();
                config.CreateMap<Pessoa, PessoaDTO>();

                config.CreateMap<VotoDTO, Voto>();
                config.CreateMap<Voto, VotoDTO>();

            });
            return mappingConfig;
        }
    }
}
