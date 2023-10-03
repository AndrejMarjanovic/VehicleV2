using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : GenericController<VehicleTypeModel, VehicleTypeGetModel, VehicleTypePostModel>
    {
        public VehicleTypeController(IGenericService<VehicleTypeModel> service, IMapper map) : base(service, map)
        {

        }
    }
}
