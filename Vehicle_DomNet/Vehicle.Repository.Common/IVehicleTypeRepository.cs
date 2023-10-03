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
    public interface IVehicleTypeRepository : IGenericRepository<VehicleType, VehicleTypeModel>
    {
        Task<IEnumerable<VehicleTypeModel>> GetFilteredVehicleTypes(string filter, Paging paging, Sorting sorting);
    }
}
