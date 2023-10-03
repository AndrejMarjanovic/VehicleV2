using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class SeatTypeRepository : GenericRepository<SeatType, SeatTypeModel>, ISeatTypeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SeatTypeRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SeatTypeModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {

            var seatTypeList = await _db.SeatType.ToListAsync();
            var seatTypes = mapper.Map<IEnumerable<SeatTypeModel>>(seatTypeList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                seatTypes = seatTypes.Where(n => n.Type.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "type":
                    if (!sorting.IsDesending)
                    {
                        seatTypes = seatTypes.OrderBy(x => x.Type);
                    }
                    else
                    {
                        seatTypes = seatTypes.OrderByDescending(x => x.Type);
                    }
                    break;


                default:
                    if (!sorting.IsDesending)
                    {
                        seatTypes = seatTypes.OrderBy(x => x.Id);
                    }
                    else
                    {
                        seatTypes = seatTypes.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return seatTypes.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
