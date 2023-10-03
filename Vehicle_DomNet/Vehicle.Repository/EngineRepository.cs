using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Common;
using Vehicle.DAL.Entities;

namespace Vehicle.Repository
{
    public class EngineRepository : GenericRepository<Engine, EngineModel>, IEngineRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EngineRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<EngineModel>> Get()
        {
            return mapper.Map<IEnumerable<EngineModel>>(dbSet
                 .Include(x => x.FuelType));
        }


        public async Task<IEnumerable<EngineModel>> GetFilteredEngines(string filter, Paging paging, Sorting sorting)
        {

            var engineList = await _db.Engine.Include(x=>x.FuelType).ToListAsync();
            var engines = mapper.Map<IEnumerable<EngineModel>>(engineList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                engines = engines.Where(n => n.Cubage.ToString().Contains(filter) 
                                          || n.Horsepower.ToString().Contains(filter)
                                          || n.EmissionStandard.ToLower().Contains(filter.ToLower()));
            }
            
            switch (sorting.SortBy)
            {
                case "cubage":
                    if (!sorting.IsDesending)
                    {
                        engines = engines.OrderBy(x => x.Cubage);
                    }
                    else
                    {
                        engines = engines.OrderByDescending(x => x.Cubage);
                    }
                    break;

                case "horsepower":
                    if (!sorting.IsDesending)
                    {
                        engines = engines.OrderBy(x => x.Horsepower);
                    }
                    else
                    {
                        engines =engines.OrderByDescending(x => x.Horsepower);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        engines = engines.OrderBy(x => x.Id);
                    }
                    else
                    {
                        engines = engines.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return engines.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
