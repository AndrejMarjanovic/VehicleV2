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
    public class SeatTypeColourService : IGenericService<SeatTypeColourModel>
    {
        private ISeatTypeColourRepository sTypeColourRepository;

        public SeatTypeColourService(ISeatTypeColourRepository seatTypeColourRepository)
        {
            sTypeColourRepository = seatTypeColourRepository;
        }

        public async Task Add(SeatTypeColourModel seatTypeColour)
        {
            try
            {
                await sTypeColourRepository.Add(seatTypeColour);

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
                await sTypeColourRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, SeatTypeColourModel seatTypeColour)
        {
            try
            {
                seatTypeColour.Id = id;
                await sTypeColourRepository.Update(seatTypeColour);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SeatTypeColourModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await sTypeColourRepository.GetFiltered(filter, paging, sorting);
        }

        public async Task<SeatTypeColourModel> GetById(int id)
        {
            SeatTypeColourModel seatTypeColour = await sTypeColourRepository.GetById(id);
            return seatTypeColour;
        }

        public async Task<IEnumerable<SeatTypeColourModel>> Get()
        {
            return await sTypeColourRepository.Get();
        }
    }
}
