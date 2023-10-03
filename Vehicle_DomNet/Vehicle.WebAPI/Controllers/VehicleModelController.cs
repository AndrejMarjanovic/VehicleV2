using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Extensions;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : GenericController<VehicleModelModel, VehicleModelGetModel, VehicleModelPostModel>
    {
        private readonly IDistributedCache _cache;
        public VehicleModelController(IGenericService<VehicleModelModel> service, IMapper map, IDistributedCache cache) : base(service, map)
        {
            _cache = cache;
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                string recordKey = "VehicleModels_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

                IEnumerable<VehicleModelModel> vehicleModels = await _cache.GetRecordAsync<IEnumerable<VehicleModelModel>>(recordKey);

                if (vehicleModels is null)
                {
                    vehicleModels = await _service.Get();

                    await _cache.SetRecordAsync(recordKey, vehicleModels);
                }

                List<VehicleModelGetModel> getVehicles = _mapper.Map<List<VehicleModelGetModel>>(vehicleModels);
                return Ok(getVehicles);
            }
            catch (StackExchange.Redis.RedisConnectionException)
            {
                IEnumerable<VehicleModelModel> vehicleModels = await _service.Get();
                List<VehicleModelGetModel> getVehicleModels = _mapper.Map<List<VehicleModelGetModel>>(vehicleModels);
                return Ok(getVehicleModels);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

