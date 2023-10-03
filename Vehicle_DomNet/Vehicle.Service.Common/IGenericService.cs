using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Get();
        Task Add(T model);
        Task Edit(int id, T model);
        Task Delete(int id);
        Task<IEnumerable<T>> GetFiltered(string filter, Paging paging, Sorting sorting);

    }
}
