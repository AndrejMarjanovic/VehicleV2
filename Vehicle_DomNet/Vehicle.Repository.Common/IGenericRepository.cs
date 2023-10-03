using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IGenericRepository<TEntity, TModel>
    {
        Task<TModel> GetById(int id);
        Task<IEnumerable<TModel>> Get();
        Task Add(TModel engine);
        Task Delete(int id);
        Task Update(TModel model);
    }
}
