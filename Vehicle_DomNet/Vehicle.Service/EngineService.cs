using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class EngineService : IGenericService<EngineModel>
    {
        private IEngineRepository engineRepository;

        public EngineService(IEngineRepository _engineRepository)
        {
            engineRepository = _engineRepository;
        }

        public async Task<EngineModel> GetById(int id)
        {
            EngineModel engine = await engineRepository.GetById(id);
            return engine;
        }

        public async Task<IEnumerable<EngineModel>> Get()
        {
            return await engineRepository.Get();
        }

        public async Task<IEnumerable<EngineModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await engineRepository.GetFilteredEngines(filter, paging, sorting);
        }

        public async Task Add(EngineModel engineModel)
        {
            try
            {

                await engineRepository.Add(engineModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, EngineModel engineModel)
        {
            try
            {
                engineModel.Id = id;
                await engineRepository.Update(engineModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await engineRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
