using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.DAL.Entities;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class RoleService : IGenericService<RoleModel>
    {
        private IRoleRepository roleRepository;

        public RoleService(IRoleRepository rRepository)
        {
            roleRepository = rRepository;
        }

        public async Task Add(RoleModel role)
        {
            try
            {
                await roleRepository.Add(role);

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
                await roleRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Edit(int id, RoleModel role)
        {
            try
            {
                role.Id = id;
                await roleRepository.Update(role);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RoleModel>> GetFiltered(string filter, Paging paging, Sorting sorting)
        {
            return await roleRepository.GetFilteredRoles(filter, paging, sorting);
        }

        public async Task<RoleModel> GetById(int id)
        {
            RoleModel role = await roleRepository.GetById(id);
            return role;
        }

        public async Task<IEnumerable<RoleModel>> Get()
        {
            return await roleRepository.Get();
        }
    }
}
