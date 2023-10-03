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
    public class FuelTypeRepository : GenericRepository<FuelType, FuelTypeModel>, IFuelTypeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FuelTypeRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FuelTypeModel>> GetFilteredFuelTypes(string filter, Paging paging, Sorting sorting)
        {

            var fuelTypeList = await _db.FuelType.ToListAsync();
            var fuelTypes = mapper.Map<IEnumerable<FuelTypeModel>>(fuelTypeList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                fuelTypes = fuelTypes.Where(n => n.Type.ToLower().Contains(filter.ToLower()));
            }
            
            switch (sorting.SortBy)
            {
                case "type":
                    if (!sorting.IsDesending)
                    {
                        fuelTypes = fuelTypes.OrderBy(x => x.Type);
                    }
                    else
                    {
                        fuelTypes = fuelTypes.OrderByDescending(x => x.Type);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        fuelTypes = fuelTypes.OrderBy(x => x.Id);
                    }
                    else
                    {
                        fuelTypes = fuelTypes.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return fuelTypes.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
