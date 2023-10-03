using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatTypeController : GenericController<SeatTypeModel, SeatTypeGetModel, SeatTypePostModel>
    {
        public SeatTypeController(IGenericService<SeatTypeModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
