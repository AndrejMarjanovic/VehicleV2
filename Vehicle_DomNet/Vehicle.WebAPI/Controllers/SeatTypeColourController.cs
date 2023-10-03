using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatTypeColourController : GenericController<SeatTypeColourModel, SeatTypeColourGetModel, SeatTypeColourPostModel>
    {
        public SeatTypeColourController(IGenericService<SeatTypeColourModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
