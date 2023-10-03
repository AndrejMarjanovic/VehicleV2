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
    public interface ISeatTypeRepository : IGenericRepository<SeatType, SeatTypeModel>
    {
        Task<IEnumerable<SeatTypeModel>> GetFiltered(string filter, Paging paging, Sorting sorting);
    }
}
