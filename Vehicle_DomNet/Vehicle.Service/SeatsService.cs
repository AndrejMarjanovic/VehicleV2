using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class SeatsService : IGenericService<SeatsModel>
    {
        private ISeatsRepository sRepository;

        public SeatsService(ISeatsRepository seatsRepository)
        {
            sRepository = seatsRepository;
        }

        public async Task Add(SeatsModel seats)
        {
            try
            {
                await sRepository.Add(seats);

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
                await sRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, SeatsModel seats)
        {
            try
            {
                seats.Id = id;
                await sRepository.Update(seats);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SeatsModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await sRepository.GetFiltered(filter, paging, sorting);
        }

        public async Task<SeatsModel> GetById(int id)
        {
            SeatsModel seats = await sRepository.GetById(id);
            return seats;
        }

        public async Task<IEnumerable<SeatsModel>> Get()
        {
            return await sRepository.Get();
        }
    }
}
