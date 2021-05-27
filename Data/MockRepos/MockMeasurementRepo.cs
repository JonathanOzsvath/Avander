using System;
using System.Collections.Generic;
using System.Linq;
using Avander.Helpers;
using Avander.Models;

namespace Avander.Data
{
    public class MockMeasurementRepo : IMeasurementRepo
    {
        public void CreateMeasurement(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MeasurementPoint> GetAllMeasurements()
        {
            var measurementPoint = new List<MeasurementPoint> { };

            for (int i = 0; i < 100; i++)
            {
                measurementPoint.Add(new MeasurementPoint { MeasurementPointId = i, Name = $"MeasurementPoint {i}" });
            }

            return measurementPoint;
        }

        public Measurement GetMeasurementById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateMeasurement(Measurement measurement)
        {
            throw new NotImplementedException();
        }

        PagedList<Measurement> IMeasurementRepo.GetAllMeasurements(MeasurementParameters measurementParameters)
        {
            var measurements = new List<Measurement> { };

            for (int i = 0; i < 100; i++)
            {
                // measurements.Add(new Measurement
                // {
                //     Id = i,
                //     Vehicle = new Vehicle { VehicleId = 0, JSN = "JSN 0", VehicleModel = "VehicleModel 0" },
                //     Shop = new Shop { ShopId = 0, Name = "Shop 0" },
                //     MeasurementPoint = new MeasurementPoint { MeasurementPointId = 0, Name = "MeasurementPointId 0" },
                //     Date = DateTime.Now,
                //     Gap = 2.1m,
                //     Flush = 1.0m
                // });
            }

            return PagedList<Measurement>.ToPagedList(measurements.AsQueryable(), 1, 20);
        }
    }
}