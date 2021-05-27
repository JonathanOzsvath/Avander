using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avander.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public int MeasurementPointId { get; set; }
        public MeasurementPoint MeasurementPoint { get; set; }

        public DateTime Date { get; set; }

        public decimal Gap { get; set; }

        public decimal Flush { get; set; }
    }
}