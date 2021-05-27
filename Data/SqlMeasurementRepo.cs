using System;
using System.Collections.Generic;
using System.Linq;
using Avander.Helpers;
using Avander.Models;
using Microsoft.EntityFrameworkCore;

namespace Avander.Data
{
    public class SqlMeasurementRepo : IMeasurementRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlMeasurementRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateMeasurement(Measurement measurement)
        {
            if (measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement));
            }

            _context.Measurements.Add(measurement);
        }

        public void DeleteMeasurement(Measurement measurement)
        {
            if (measurement == null)
            {
                throw new ArgumentNullException(nameof(measurement));
            }

            _context.Measurements.Remove(measurement);
        }

        public PagedList<Measurement> GetAllMeasurements(MeasurementParameters measurementParameters)
        {
            var measurements = _context.Measurements
                                .Include(m => m.Shop)
                                .Include(m => m.MeasurementPoint)
                                .Include(m => m.Vehicle)
                                .AsQueryable();

            if (measurementParameters.MeasurementPoint != null)
            {
                measurements = measurements.Where(s => s.MeasurementPoint.Name.Contains(measurementParameters.MeasurementPoint));
            }

            if (measurementParameters.Shop != null)
            {
                measurements = measurements.Where(s => s.Shop.Name.Contains(measurementParameters.Shop));
            }

            if (measurementParameters.Vehicle != null)
            {
                measurements = measurements.Where(s => s.Vehicle.JSN.Contains(measurementParameters.Vehicle));
            }

            if (measurementParameters.Dates != null)
            {
                var dates = measurementParameters.Dates.Split(",");
                var date1 = DateTime.Parse(dates[0]);
                var date2 = DateTime.Parse(dates[1]);

                if (date2 < date1)
                {
                    var date3 = date2;
                    date2 = date1;
                    date1 = date3;
                }

                measurements = measurements.Where(s => s.Date >= date1 && s.Date <= date2);
            }

            return PagedList<Measurement>.ToPagedList(measurements, measurementParameters.PageNumber, measurementParameters.PageSize);
        }

        public Measurement GetMeasurementById(int id)
        {
            return _context.Measurements
                            .Include(m => m.Shop)
                            .Include(m => m.MeasurementPoint)
                            .Include(m => m.Vehicle)
                            .FirstOrDefault(m => m.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMeasurement(Measurement measurement)
        {
            // Nothing
        }
    }
}