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
    public class RoleRepository : GenericRepository<Role, RoleModel>, IRoleRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoleModel>> GetFilteredRoles(string filter, Paging paging, Sorting sorting)
        {

            var roleList = await _db.Role.ToListAsync();
            var roles = mapper.Map<IEnumerable<RoleModel>>(roleList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                roles = roles.Where(n => n.Name.ToLower().Contains(filter.ToLower()));
            }
            
            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        roles = roles.OrderBy(x => x.Name);
                    }
                    else
                    {
                        roles = roles.OrderByDescending(x => x.Name);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        roles = roles.OrderBy(x => x.Id);
                    }
                    else
                    {
                        roles = roles.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return roles.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
