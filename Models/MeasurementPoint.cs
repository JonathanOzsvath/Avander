using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Avander.Models
{
    public class MeasurementPoint
    {
        [Key]
        public int MeasurementPointId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Measurement> Measurement { get; set; }
    }
}