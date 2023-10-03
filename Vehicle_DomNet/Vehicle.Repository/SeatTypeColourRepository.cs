using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vehicle.Common;
using Vehicle.DAL;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class SeatTypeColourRepository : GenericRepository<SeatTypeColour, SeatTypeColourModel>, ISeatTypeColourRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;

        public SeatTypeColourRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
        }

        public override async Task<IEnumerable<SeatTypeColourModel>> Get()
        {
            return mapper.Map<IEnumerable<SeatTypeColourModel>>(dbSet
                .Include(x => x.SeatType)
                .Include(x => x.Colour));
        }

        public async Task<IEnumerable<SeatTypeColourModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {

            var seatTypeColourList = await _db.SeatTypeColour
                                    .Include(m => m.SeatType)
                                    .Include(m => m.Colour).ToListAsync();

            var seatTypeColours = mapper.Map<IEnumerable<SeatTypeColourModel>>(seatTypeColourList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                seatTypeColours = seatTypeColours.Where(n => n.SeatType.Type.ToLower().Contains(filter.ToLower())
                                                          || n.Colour.Name.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "type":
                    if (!sorting.IsDesending)
                    {
                        seatTypeColours = seatTypeColours.OrderBy(x => x.SeatType.Type);
                    }
                    else
                    {
                        seatTypeColours = seatTypeColours.OrderByDescending(x => x.SeatType.Type);
                    }
                    break;

                case "colour":
                    if (!sorting.IsDesending)
                    {
                        seatTypeColours = seatTypeColours.OrderBy(x => x.Colour.Name);
                    }
                    else
                    {
                        seatTypeColours = seatTypeColours.OrderByDescending(x => x.Colour.Name);
                    }
                    break;


                default:
                    if (!sorting.IsDesending)
                    {
                        seatTypeColours = seatTypeColours.OrderBy(x => x.Id);
                    }
                    else
                    {
                        seatTypeColours = seatTypeColours.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return seatTypeColours.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
