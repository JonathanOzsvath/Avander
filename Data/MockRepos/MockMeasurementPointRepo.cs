using System.Collections.Generic;
using Avander.Models;

namespace Avander.Data
{
    public class MockMeasurementPointRepo : IMeasurementPointRepo
    {
        public IEnumerable<MeasurementPoint> GetAllMeasurementPoints()
        {
            var measurementPoint = new List<MeasurementPoint>{};

            for(int i=0; i < 100; i++)
            {
                measurementPoint.Add(new MeasurementPoint{MeasurementPointId=i, Name=$"MeasurementPoint {i}"});
            }

            return measurementPoint;
        }
    }
}