using System.Collections.Generic;
using Avander.Models;

namespace Avander.Data
{
    public interface IVehicleRepo
    {
        IEnumerable<Vehicle> GetAllVehicles();
    }
}