using System.Collections.Generic;
using System.Linq;
using Avander.Models;

namespace Avander.Data
{
    public class SqlVehicleRepo : IVehicleRepo
    {
        private readonly ApplicationDbContext _context;

        public SqlVehicleRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.ToList();
        }
    }
}