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
    public class FuelTypeService : IGenericService<FuelTypeModel>
    {
        private IFuelTypeRepository fTypeRepository;

        public FuelTypeService(IFuelTypeRepository fuelTypeRepository)
        {
            fTypeRepository = fuelTypeRepository;
        }

        public async Task Add(FuelTypeModel fuelType)
        {
            try
            {
                await fTypeRepository.Add(fuelType);

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
                await fTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, FuelTypeModel fuelType)
        {
            try
            {
                fuelType.Id = id;
                await fTypeRepository.Update(fuelType);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FuelTypeModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await fTypeRepository.GetFilteredFuelTypes(filter, paging, sorting);
        }

        public async Task<FuelTypeModel> GetById(int id)
        {
            FuelTypeModel fuelType = await fTypeRepository.GetById(id);
            return fuelType;
        }

        public async Task<IEnumerable<FuelTypeModel>> Get()
        {
            return await fTypeRepository.Get();
        }
    }
}
