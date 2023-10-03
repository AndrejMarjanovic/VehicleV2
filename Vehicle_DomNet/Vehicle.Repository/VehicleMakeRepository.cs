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
    public class VehicleMakeRepository : GenericRepository<VehicleMake, VehicleMakeModel>, IVehicleMakeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakeRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleMakeModel>> GetFilteredVehicleMakes(string filter, Paging paging, Sorting sorting)
        {

            var vMakeList = await _db.VehicleMake.ToListAsync();
            var vehicleMakes = mapper.Map<IEnumerable<VehicleMakeModel>>(vMakeList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                vehicleMakes = vehicleMakes.Where(n => n.Name.ToLower().Contains(filter.ToLower()) || n.Abrv.ToLower().Contains(filter.ToLower()));
            }
            
            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Name);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Name);
                    }
                    break;

                case "abrv":
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Abrv);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Abrv);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return vehicleMakes.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
