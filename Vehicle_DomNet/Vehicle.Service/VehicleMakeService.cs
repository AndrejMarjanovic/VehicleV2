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
    public class VehicleMakeService : IGenericService<VehicleMakeModel>
    {
        private IVehicleMakeRepository VMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            VMakeRepository = vehicleMakeRepository;
        }
        public async Task<VehicleMakeModel> GetById(int id)
        {
            VehicleMakeModel vehicleMake = await VMakeRepository.GetById(id);
            return vehicleMake;
        }

        public async Task<IEnumerable<VehicleMakeModel>> Get()
        {
            return await VMakeRepository.Get();
        }

        public async Task<IEnumerable<VehicleMakeModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await VMakeRepository.GetFilteredVehicleMakes(filter, paging, sorting);
        }

        public async Task Add(VehicleMakeModel vehicleMakeModel)
        {
            try
            {
               await VMakeRepository.Add(vehicleMakeModel);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, VehicleMakeModel vehicleMakeModel)
        {
            try
            {
                vehicleMakeModel.Id = id;
                await VMakeRepository.Update(vehicleMakeModel);

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
                await VMakeRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
