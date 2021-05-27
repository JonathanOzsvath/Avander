using System.Collections.Generic;
using Avander.Helpers;
using Avander.Models;

namespace Avander.Data
{
    public interface IMeasurementRepo
    {
        bool SaveChanges();

        PagedList<Measurement> GetAllMeasurements(MeasurementParameters measurementParameters);

        Measurement GetMeasurementById(int id);

        void CreateMeasurement(Measurement measurement);

        void UpdateMeasurement(Measurement measurement);

        void DeleteMeasurement(Measurement measurement);
    }
}