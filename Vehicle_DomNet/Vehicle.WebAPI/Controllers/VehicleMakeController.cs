using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : GenericController<VehicleMakeModel, VehicleMakeGetModel, VehicleMakePostModel>
    { 
        public VehicleMakeController(IGenericService<VehicleMakeModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
