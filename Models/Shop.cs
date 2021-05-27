using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avander.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public ICollection<Measurement> Measurement { get; set; }
    }
}