using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IDetailedFilters
    {
       Task<IEnumerable<VehicleEntityModel>> GetWithDetailedFilter(string make, string model, int producedFrom, int producedTo, double priceFrom, double priceTo, int hpFrom, int hpTo, int transmissionId, int vehicleTypeId);
    }
}
