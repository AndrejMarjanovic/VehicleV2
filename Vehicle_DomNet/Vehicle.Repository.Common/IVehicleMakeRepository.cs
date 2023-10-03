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
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMake, VehicleMakeModel>
    {
        Task<IEnumerable<VehicleMakeModel>> GetFilteredVehicleMakes(string filter, Paging paging, Sorting sorting);
    }
}
