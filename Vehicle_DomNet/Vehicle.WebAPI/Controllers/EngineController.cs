using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : GenericController<EngineModel, EngineGetModel, EnginePostModel>
    {
        public EngineController(IGenericService<EngineModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
