using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IUserService : IGenericService<UserModel>
    { 
        Task<UserModel> Login(string username, string password);
    }
}
