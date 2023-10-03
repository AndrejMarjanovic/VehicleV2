using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Common;
using Vehicle.Service.Common;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenericController<TModel, TGetModel, TPostModel> : ControllerBase where TModel : class
    {
        protected readonly IGenericService<TModel> _service;
        protected IMapper _mapper;
        public GenericController(IGenericService<TModel> service, IMapper map)
        {
            _service = service;
            _mapper = map;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TGetModel>> GetById(int id)
        {
            try
            {
                TModel model = await _service.GetById(id);
                TGetModel getModel = _mapper.Map<TGetModel>(model);
                return getModel == null ? NotFound() : Ok(getModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            IEnumerable<TModel> models = await _service.Get();
            List<TGetModel> getModels = _mapper.Map<List<TGetModel>>(models);
            return Ok(getModels);
        }

        [HttpGet("Filtered")]
        public virtual async Task<IActionResult> GetFiltered(string? search, int? page, string? sortBy, bool isDesc)
        {
            Sorting sorting = new Sorting(sortBy, isDesc);
            Paging paging = new Paging(page);
            IEnumerable<TModel> models = await _service.GetFiltered(search, paging, sorting);
            List<TGetModel> getModel = _mapper.Map<List<TGetModel>>(models);
            return Ok(getModel);

        }

        [HttpPost]
        public virtual async Task<ActionResult<TPostModel>> Post(TPostModel postModel)
        {
            try
            {
                TModel model = _mapper.Map<TModel>(postModel);
                await _service.Add(model);
                return CreatedAtAction(nameof(Get), postModel);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TPostModel>> Put(int id, TPostModel postModel)
        {
            try
            {
                TModel model = _mapper.Map<TModel>(postModel);
                await _service.Edit(id, model);
                return Ok(postModel);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
           // TModel model = await _service.GetById(id);
            try
            {
                await _service.Delete(id);
                //return Ok(model);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


    }
}
