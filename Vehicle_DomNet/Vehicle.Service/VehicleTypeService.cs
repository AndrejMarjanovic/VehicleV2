using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleTypeService : IGenericService<VehicleTypeModel>
    {
        private IVehicleTypeRepository VTypeRepository;

        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository)
        {
            VTypeRepository = vehicleTypeRepository;
        }

        public async Task Add(VehicleTypeModel vehicleType)
        {
            try
            {
                await VTypeRepository.Add(vehicleType);

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
                await VTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, VehicleTypeModel vehicleType)
        {
            try
            {
                vehicleType.Id = id;
                await VTypeRepository.Update(vehicleType);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<VehicleTypeModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await VTypeRepository.GetFilteredVehicleTypes(filter, paging, sorting);
        }

        public async Task<VehicleTypeModel> GetById(int id)
        {
            VehicleTypeModel vehicleType = await VTypeRepository.GetById(id);
            return vehicleType;
        }

        public async Task<IEnumerable<VehicleTypeModel>> Get()
        {
            return await VTypeRepository.Get();
        }
    }
}
