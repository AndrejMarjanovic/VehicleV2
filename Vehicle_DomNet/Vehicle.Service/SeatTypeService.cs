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
    public class SeatTypeService : IGenericService<SeatTypeModel>
    {
        private ISeatTypeRepository sTypeRepository;

        public SeatTypeService(ISeatTypeRepository seatTypeRepository)
        {
            sTypeRepository = seatTypeRepository;
        }

        public async Task Add(SeatTypeModel seatType)
        {
            try
            {
                await sTypeRepository.Add(seatType);

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
                await sTypeRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, SeatTypeModel seatType)
        {
            try
            {
                seatType.Id = id;
                await sTypeRepository.Update(seatType);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SeatTypeModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await sTypeRepository.GetFiltered(filter, paging, sorting);
        }

        public async Task<SeatTypeModel> GetById(int id)
        {
            SeatTypeModel seatType = await sTypeRepository.GetById(id);
            return seatType;
        }

        public async Task<IEnumerable<SeatTypeModel>> Get()
        {
            return await sTypeRepository.Get();
        }
    }
}
