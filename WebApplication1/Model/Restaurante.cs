using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VoteInRestaurant.Model.Base;

namespace VoteInRestaurant.Model
{
    [Table("restaurant")]
    public class Restaurante : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}
