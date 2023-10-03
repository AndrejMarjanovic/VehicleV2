using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<UserModel> GetById(int id)
        {
            UserModel user = await userRepository.GetById(id);
            return user;
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            return await userRepository.Get();
        }

        public async Task<IEnumerable<UserModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await userRepository.GetFilteredUsers(filter, paging, sorting);
        }

        public async Task Add(UserModel user)
        {
            try
            {
                await userRepository.Add(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, UserModel user)
        {
            try
            {
                user.Id = id;
                await userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<UserModel> Login(string username, string password)
        {
            IEnumerable<UserModel> users = await Get();
            UserModel user = users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var newHash = Hashing.GenerateHash(user.PasswordSalt, password);

                if (newHash == user.PasswordHash)
                {
                    return user;
                }
            }
            return null;
        }

    }
}
