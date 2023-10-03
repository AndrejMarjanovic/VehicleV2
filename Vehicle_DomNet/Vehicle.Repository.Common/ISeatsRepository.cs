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
    public interface ISeatsRepository : IGenericRepository<Seats, SeatsModel>
    {
        Task<IEnumerable<SeatsModel>> GetFiltered(string filter, Paging paging, Sorting sorting);
    }
}
