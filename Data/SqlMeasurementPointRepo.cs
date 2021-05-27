using System.Collections.Generic;
using System.Linq;
using Avander.Models;

namespace Avander.Data
{
    public class SqlMeasurementPointRepo : IMeasurementPointRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlMeasurementPointRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MeasurementPoint> GetAllMeasurementPoints()
        {
            return _context.MeasurementPoints.ToList();
        }
    }
}