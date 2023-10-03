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

namespace Vehicle.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel, VehicleModelModel>, IVehicleModelRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<VehicleModelModel>> Get()
        {
            return mapper.Map<IEnumerable<VehicleModelModel>>(dbSet
                .Include(x => x.VehicleMake));
        }


        public async Task<IEnumerable<VehicleModelModel>> GetFilteredVehicleModels(string filter, Paging paging, Sorting sorting)
        {

            var vModelList = await _db.VehicleModel.Include(m=>m.VehicleMake).ToListAsync();
            var vehicleModels = mapper.Map<IEnumerable<VehicleModelModel>>(vModelList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                vehicleModels = vehicleModels.Where(m => m.Name.ToLower().Contains(filter.ToLower()) 
                                                 || m.Abrv.ToLower().Contains(filter.ToLower()) 
                                                 || m.VehicleMake.Name.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.Name);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.Name);
                    }
                    break;

                case "make":
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.VehicleMake.Name);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.VehicleMake.Name);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return vehicleModels.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
