using System;

namespace Avander.Dtos
{
    public class MeasurementUpdateDto
    {
        public int VehicleId { get; set; }

        public int ShopId { get; set; }


        public int MeasurementPointId { get; set; }

        public DateTime Date { get; set; }

        public decimal Gap { get; set; }

        public decimal Flush { get; set; }
    }
}