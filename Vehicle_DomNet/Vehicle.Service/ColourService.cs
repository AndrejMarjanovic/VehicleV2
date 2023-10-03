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
    public class ColourService : IGenericService<ColourModel>
    {
        private IColourRepository colourRepository;

        public ColourService(IColourRepository cRepository)
        {
            colourRepository = cRepository;
        }

        public async Task Add(ColourModel colour)
        {
            try
            {
                await colourRepository.Add(colour);

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
                await colourRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, ColourModel colour)
        {
            try
            {
                colour.Id = id;
                await colourRepository.Update(colour);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ColourModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await colourRepository.GetFilteredColours(filter, paging, sorting);
        }

        public async Task<ColourModel> GetById(int id)
        {
            ColourModel colour = await colourRepository.GetById(id);
            return colour;
        }

        public async Task<IEnumerable<ColourModel>> Get()
        {
            return await colourRepository.Get();
        }
    }
}
