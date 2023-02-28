using System.ComponentModel.DataAnnotations;
using VoteInRestaurant.Model.Base;

namespace VoteInRestaurant.Model
{
    public class Pessoa : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
