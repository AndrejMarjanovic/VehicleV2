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
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;

namespace Vehicle.Repository
{
    public class UserRepository : GenericRepository<User, UserModel>, IUserRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork) : base(context, map, unitOfWork)
        {
            _db = context;
            mapper = map;
            _unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<UserModel>> Get()
        {
            return mapper.Map<IEnumerable<UserModel>>(dbSet
                .Include(x => x.Role));
        }

        public virtual async Task Add(UserModel userModel)
        {
            try
            {
                if (await dbSet.AnyAsync(u => u.Username == userModel.Username))
                {
                    throw new Exception("User with the same username already exists.");
                }
                else if (await dbSet.AnyAsync(u => u.Email == userModel.Email))
                {
                    throw new Exception("User with the same E-mail already exists.");
                }
                else if(await dbSet.AnyAsync(u => u.Phone == userModel.Phone))
                {
                    throw new Exception("User with the same phone number already exists.");
                }

                User user = mapper.Map<User>(userModel);
                await dbSet.AddAsync(user);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task Update(UserModel userModel)
        {
            try
            {
                var user = await dbSet.FindAsync(userModel.Id);

                if (await dbSet.Where(u => u.Username == userModel.Username && u.Id != userModel.Id).AnyAsync())
                {
                    throw new Exception("User with the same username already exists.");
                }
                else if (await dbSet.Where(u => u.Email == userModel.Email && u.Id != userModel.Id).AnyAsync())
                {
                    throw new Exception("User with the same E-mail already exists.");
                }
                else if (await dbSet.Where(u => u.Phone == userModel.Phone && u.Id != userModel.Id).AnyAsync())
                {
                    throw new Exception("User with the same phone number already exists.");
                }

                if (user == null)
                {
                    throw new Exception("Unable to find specified user.");
                }

                user.Name = userModel.Name;
                user.LastName = userModel.LastName;
                user.Username = userModel.Username;
                user.Phone = userModel.Phone;
                user.Email = userModel.Email;
                
                if(userModel.RoleId == 0)
                {
                    user.RoleId = user.RoleId;
                }
                else
                {
                    user.RoleId = userModel.RoleId;
                }

                user.PasswordSalt = userModel.PasswordSalt ?? user.PasswordSalt;
                user.PasswordHash = userModel.PasswordHash ?? user.PasswordHash;

                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UserModel>> GetFilteredUsers(string filter, Paging paging, Sorting sorting)
        {

            var userList = await _db.User.Include(x=>x.Role).ToListAsync();
            var users = mapper.Map<IEnumerable<UserModel>>(userList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                users = users.Where(n => n.Name.ToLower().Contains(filter.ToLower()) 
                                      || n.LastName.ToLower().Contains(filter.ToLower())
                                      || n.Username.ToLower().Contains(filter.ToLower()) 
                                      || n.Role.Name.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        users = users.OrderBy(x => x.Name);
                    }
                    else
                    {
                        users = users.OrderByDescending(x => x.Name);
                    }
                    break;

                case "lastname":
                    if (!sorting.IsDesending)
                    {
                        users = users.OrderBy(x => x.LastName);
                    }
                    else
                    {
                        users = users.OrderByDescending(x => x.LastName);
                    }
                    break;

                case "username":
                    if (!sorting.IsDesending)
                    {
                        users = users.OrderBy(x => x.Username);
                    }
                    else
                    {
                        users = users.OrderByDescending(x => x.Username);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        users = users.OrderBy(x => x.Id);
                    }
                    else
                    {
                        users = users.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return users.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
