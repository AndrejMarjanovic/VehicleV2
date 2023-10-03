using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleModelService : IGenericService<VehicleModelModel>
    {
        private IVehicleModelRepository VModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            VModelRepository = vehicleModelRepository;
        }
        public async Task<VehicleModelModel> GetById(int id)
        {
            VehicleModelModel vehicleModel = await VModelRepository.GetById(id);
            return vehicleModel;
        }

        public async Task<IEnumerable<VehicleModelModel>> Get()
        {
            return await VModelRepository.Get();
        }

        public async Task<IEnumerable<VehicleModelModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await VModelRepository.GetFilteredVehicleModels(filter, paging, sorting);
        }

        public async Task Add(VehicleModelModel vehicleModelModel)
        {
            try
            {
               await VModelRepository.Add(vehicleModelModel);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, VehicleModelModel vehicleModelModel)
        {
            try
            {
                vehicleModelModel.Id = id;
                await VModelRepository.Update(vehicleModelModel);

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
                await VModelRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
