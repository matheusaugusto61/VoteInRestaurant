using VoteInRestaurant.Model;

namespace VoteInRestaurant.Model.DTO
{
    public class VotoDTO
    {
        public long Id { get; set; }
        public long RestauranteID { get; set; }
        public DateTime DataHora { get; set; }
        public long IdPessoa { get; set; }
        
    }
}
