using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL;
using Vehicle.Model.Common;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.DAL.Entities;

namespace Vehicle.Repository
{
    public class VehicleTypeRepository : GenericRepository<VehicleType, VehicleTypeModel>, IVehicleTypeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleTypeRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleTypeModel>> GetFilteredVehicleTypes(string filter, Paging paging, Sorting sorting)
        {

            var vTypeList = await _db.VehicleType.ToListAsync();
            var vehicleTypes = mapper.Map<IEnumerable<VehicleTypeModel>>(vTypeList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                vehicleTypes = vehicleTypes.Where(n => n.Name.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        vehicleTypes = vehicleTypes.OrderBy(x => x.Name);
                    }
                    else
                    {
                        vehicleTypes = vehicleTypes.OrderByDescending(x => x.Name);
                    }
                    break;


                default:
                    if (!sorting.IsDesending)
                    {
                        vehicleTypes = vehicleTypes.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicleTypes = vehicleTypes.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return vehicleTypes.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
