using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Vehicle.Repository
{
    public class VehicleRepository : GenericRepository<VehicleEntity, VehicleEntityModel>, IVehicleRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;

        public VehicleRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
        }

        public override async Task<IEnumerable<VehicleEntityModel>> Get()
        {
            return mapper.Map<IEnumerable<VehicleEntityModel>>(dbSet
                .Include(x => x.VehicleModel).ThenInclude(x => x.VehicleMake)
                .Include(x => x.VehicleType)
                .Include(x => x.Engine).ThenInclude(x => x.FuelType)
                .Include(x => x.Transmission));
        }

        public async Task<IEnumerable<VehicleEntityModel>> GetFilteredVehicles(string filter, Paging paging, Sorting sorting)
        {

            var vehicleList = await _db.Vehicle
                .Include(m => m.VehicleModel).ThenInclude(x => x.VehicleMake)
                .Include(x => x.VehicleType)
                .Include(m => m.Engine).ThenInclude(x => x.FuelType)
                .Include(x => x.Transmission)
                .ToListAsync();

            var vehicles = mapper.Map<IEnumerable<VehicleEntityModel>>(vehicleList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                vehicles = vehicles.Where(n => n.ProductionYear.ToString().ToLower().Contains(filter.ToLower())
                                            || n.VehicleModel.Name.ToLower().Contains(filter.ToLower())
                                            || n.VehicleModel.VehicleMake.Name.ToLower().Contains(filter.ToLower())
                                            || n.VehicleType.Name.ToLower().Contains(filter.ToLower())
                                            || n.ProductionYear.ToString().Contains(filter.ToLower())
                                            || n.Mileage.ToString().Contains(filter.ToLower())
                );
            }

            switch (sorting.SortBy)
            {
                case "mileage":
                    if (!sorting.IsDesending)
                    {
                        vehicles = vehicles.OrderBy(x => x.Mileage);
                    }
                    else
                    {
                        vehicles = vehicles.OrderByDescending(x => x.Mileage);
                    }
                    break;

                case "year":
                    if (!sorting.IsDesending)
                    {
                        vehicles = vehicles.OrderBy(x => x.ProductionYear);
                    }
                    else
                    {
                        vehicles = vehicles.OrderByDescending(x => x.ProductionYear);
                    }
                    break;

                case "model":
                    if (!sorting.IsDesending)
                    {
                        vehicles = vehicles.OrderBy(x => x.VehicleModel.Name);
                    }
                    else
                    {
                        vehicles = vehicles.OrderByDescending(x => x.VehicleModel.Name);
                    }
                    break;

                case "make":
                    if (!sorting.IsDesending)
                    {
                        vehicles = vehicles.OrderBy(x => x.VehicleModel.VehicleMake.Name);
                    }
                    else
                    {
                        vehicles = vehicles.OrderByDescending(x => x.VehicleModel.VehicleMake.Name);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        vehicles = vehicles.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicles = vehicles.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return vehicles.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

        public async Task<IEnumerable<VehicleEntityModel>> GetVehiclesWithDetailedFilters(string make, string model, int producedFrom, int producedTo, double priceFrom, double priceTo, int hpFrom, int hpTo, int transmissionId, int vehicleTypeId)
        {
            var query = _db.Vehicle
                .Include(m => m.VehicleModel).ThenInclude(x => x.VehicleMake)
                .Include(x => x.VehicleType)
                .Include(m => m.Engine).ThenInclude(x => x.FuelType)
                .Include(x => x.Transmission)
                .AsQueryable();

            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(v => v.VehicleModel.VehicleMake.Name == make);
            }

            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(v => v.VehicleModel.Name == model);
            }

            if (producedFrom > 0)
            {
                query = query.Where(v => v.ProductionYear >= producedFrom);
            }

            if (producedTo > 0)
            {
                query = query.Where(v => v.ProductionYear <= producedTo);
            }

            if (priceFrom > 0)
            {
                query = query.Where(v => v.Price >= priceFrom);
            }

            if (priceTo > 0)
            {
                query = query.Where(v => v.Price <= priceTo);
            }

            if (hpFrom > 0)
            {
                query = query.Where(v => v.Engine.Horsepower >= hpFrom);
            }

            if (hpTo > 0)
            {
                query = query.Where(v => v.Engine.Horsepower <= hpTo);
            }

            if (transmissionId > 0)
            {
                query = query.Where(v => v.Transmission.Id == transmissionId);
            }

            if (vehicleTypeId > 0)
            {
                query = query.Where(v => v.VehicleType.Id == vehicleTypeId);
            }

            var vehicleList = await query.ToListAsync();
            var vehicles = mapper.Map<IEnumerable<VehicleEntityModel>>(vehicleList);
            return vehicles;
        }

    }
}
