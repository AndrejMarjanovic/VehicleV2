using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleService : IGenericService<VehicleEntityModel>, IDetailedFilters
    {
        private IVehicleRepository VRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            VRepository = vehicleRepository;
        }
        public async Task<VehicleEntityModel> GetById(int id)
        {
            VehicleEntityModel vehicle = await VRepository.GetById(id);
            return vehicle;
        }

        public async Task<IEnumerable<VehicleEntityModel>> Get()
        {
            return await VRepository.Get();
        }

        public async Task<IEnumerable<VehicleEntityModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await VRepository.GetFilteredVehicles(filter, paging, sorting);
        }

        public async Task Add(VehicleEntityModel vehicleEntityModel)
        {
            try
            {
               await VRepository.Add(vehicleEntityModel);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, VehicleEntityModel vehicleEntityModel)
        {
            try
            {
                vehicleEntityModel.Id = id;
                await VRepository.Update(vehicleEntityModel);

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
                await VRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<VehicleEntityModel>> GetWithDetailedFilter(string make, string model, int producedFrom, int producedTo, double priceFrom, double priceTo, int hpFrom, int hpTo, int transmissionId, int vehicleTypeId)
        {
            return await VRepository.GetVehiclesWithDetailedFilters(make, model, producedFrom, producedTo, priceFrom, priceTo, hpFrom, hpTo, transmissionId, vehicleTypeId);
        }
    }
}
