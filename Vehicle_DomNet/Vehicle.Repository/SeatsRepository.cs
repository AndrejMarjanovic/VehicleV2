using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vehicle.Common;
using Vehicle.DAL;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class SeatsRepository : GenericRepository<Seats, SeatsModel>, ISeatsRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SeatsRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<SeatsModel>> Get()
        {
            return mapper.Map<IEnumerable<SeatsModel>>(dbSet
                .Include(x => x.SeatTypeColour)
                .ThenInclude(x => x.SeatType)
                .Include(x => x.SeatTypeColour)
                .ThenInclude(x => x.Colour));
        }

        public async Task<IEnumerable<SeatsModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {

            var seatsList = await _db.Seats
                                    .Include(m => m.SeatTypeColour)
                                    .ThenInclude(m => m.SeatType)
                                    .Include(m => m.SeatTypeColour)
                                    .ThenInclude(m => m.Colour).ToListAsync();

            var seats = mapper.Map<IEnumerable<SeatsModel>>(seatsList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                seats = seats.Where(n => n.SeatTypeColour.SeatType.Type.ToLower().Contains(filter.ToLower())
                                      || n.SeatTypeColour.Colour.Name.ToLower().Contains(filter.ToLower())
                                      || n.NumberOfSeats.ToString().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "seattypecolour":
                    if (!sorting.IsDesending)
                    {
                        seats = seats.OrderBy(x => x.SeatTypeColour.ToString());
                    }
                    else
                    {
                        seats = seats.OrderByDescending(x => x.SeatTypeColour.ToString());
                    }
                    break;


                default:
                    if (!sorting.IsDesending)
                    {
                        seats = seats.OrderBy(x => x.Id);
                    }
                    else
                    {
                        seats = seats.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return seats.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
