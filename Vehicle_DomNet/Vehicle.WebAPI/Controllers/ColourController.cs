using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : GenericController<ColourModel, ColourGetModel, ColourPostModel>
    {
        public ColourController(IGenericService<ColourModel> service, IMapper map) : base(service, map)
        {

        }

    }
}
