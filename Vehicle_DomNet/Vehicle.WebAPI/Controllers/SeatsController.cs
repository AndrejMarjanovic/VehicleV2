using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : GenericController<SeatsModel, SeatsGetModel, SeatsPostModel>
    {
        public SeatsController(IGenericService<SeatsModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
