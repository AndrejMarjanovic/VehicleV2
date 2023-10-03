using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : GenericController<FuelTypeModel, FuelTypeGetModel, FuelTypePostModel>
    {
        public FuelTypeController(IGenericService<FuelTypeModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
