using System.Collections.Generic;
using Avander.Models;

namespace Avander.Data
{
    public interface IMeasurementPointRepo
    {
        IEnumerable<MeasurementPoint> GetAllMeasurementPoints();
    }
}