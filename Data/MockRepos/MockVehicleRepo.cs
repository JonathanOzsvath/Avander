using System.Collections.Generic;
using Avander.Models;

namespace Avander.Data
{
    public class MockVehicleRepo : IVehicleRepo
    {
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var vehicles = new List<Vehicle>{};

            for(int i=0; i < 100; i++)
            {
                vehicles.Add(new Vehicle{VehicleId=i, JSN=$"JSN {i}", VehicleModel=$"VehicleModel {i}"});
            }

            return vehicles;
        }
    }
}