using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoteInRestaurant.Model;
using VoteInRestaurant.Model.Base;

namespace VoteInRestaurant.Model
{
    public class Voto : BaseEntity
    {
        [ForeignKey("Restaurant")]
        public long RestauranteID { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [ForeignKey("Pessoa")]
        public long IdPessoa { get; set; }
        public virtual Restaurante Restaurante { get; set; }
        public virtual Pessoa Pessoa { get; set; }

}
}
