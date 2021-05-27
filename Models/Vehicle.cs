using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avander.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [MaxLength(15)]
        public string JSN { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehicleModel { get; set; }

        public ICollection<Measurement> Measurement { get; set; }
    }
}