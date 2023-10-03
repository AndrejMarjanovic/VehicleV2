using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IVehicleRepository : IGenericRepository<VehicleEntity, VehicleEntityModel>
    {
        Task<IEnumerable<VehicleEntityModel>> GetFilteredVehicles(string filter, Paging paging, Sorting sorting);
        Task<IEnumerable<VehicleEntityModel>> GetVehiclesWithDetailedFilters(string make, string model, int producedFrom, int producedTo, double priceFrom, double priceTo, int hpFrom, int hpTo, int transmissionId, int vehicleTypeId);

    }
}
