using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel, VehicleModelModel>
    {
        Task<IEnumerable<VehicleModelModel>> GetFilteredVehicleModels(string filter, Paging paging, Sorting sorting);
    }
}
