using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : GenericController<RoleModel, RoleGetModel, RolePostModel>
    {
        public RoleController(IGenericService<RoleModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
