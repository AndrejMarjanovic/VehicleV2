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
    public class ColourRepository : GenericRepository<Colour, ColourModel>, IColourRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ColourRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ColourModel>> GetFilteredColours(string filter, Paging paging, Sorting sorting)
        {

            var colourList = await _db.Colour.ToListAsync();
            var colours = mapper.Map<IEnumerable<ColourModel>>(colourList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                colours = colours.Where(n => n.Name.ToLower().Contains(filter.ToLower())
                                          || n.ColourCode.ToLower().Contains(filter.ToLower()));
            }
            
            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        colours = colours.OrderBy(x => x.Name);
                    }
                    else
                    {
                        colours = colours.OrderByDescending(x => x.Name);
                    }
                    break;

                case "code":
                    if (!sorting.IsDesending)
                    {
                        colours = colours.OrderBy(x => x.ColourCode);
                    }
                    else
                    {
                        colours = colours.OrderByDescending(x => x.ColourCode);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        colours = colours.OrderBy(x => x.Id);
                    }
                    else
                    {
                        colours = colours.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return colours.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
