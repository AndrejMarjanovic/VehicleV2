using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Vehicle.WebAPI.Extensions;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VehicleController : GenericController<VehicleEntityModel, VehicleEntityGetModel, VehicleEntityPostModel>
    {
        private readonly IDistributedCache _cache;
        public VehicleController(IGenericService<VehicleEntityModel> service, IMapper map, IDistributedCache cache) : base(service, map)
        {
            _cache = cache;
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                string recordKey = "Vehicles_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

                IEnumerable<VehicleEntityModel> vehicles = await _cache.GetRecordAsync<IEnumerable<VehicleEntityModel>>(recordKey);

                if (vehicles is null)
                {
                    vehicles = await _service.Get();

                    await _cache.SetRecordAsync(recordKey, vehicles);
                }

                List<VehicleEntityGetModel> getVehicles = _mapper.Map<List<VehicleEntityGetModel>>(vehicles);
                return Ok(getVehicles);
            }
            catch (StackExchange.Redis.RedisConnectionException)
            {
                IEnumerable<VehicleEntityModel> vehicles = await _service.Get();
                List<VehicleEntityGetModel> getVehicles = _mapper.Map<List<VehicleEntityGetModel>>(vehicles);
                return Ok(getVehicles);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

