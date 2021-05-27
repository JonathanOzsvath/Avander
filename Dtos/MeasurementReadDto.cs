using System;
using Avander.Dtos;

namespace Avander.Dtos
{
    public class MeasurementReadDto
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public VehicleReadDto Vehicle { get; set; }

        public int ShopId { get; set; }

        public ShopReadDto Shop { get; set; }

        public int MeasurementPointId { get; set; }
        public MeasurementPointReadDto MeasurementPoint { get; set; }

        public DateTime Date { get; set; }

        public decimal Gap { get; set; }

        public decimal Flush { get; set; }
    }
}