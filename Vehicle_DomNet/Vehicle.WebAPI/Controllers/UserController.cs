using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Globalization;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Extensions;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<UserModel, UserGetModel, UserPostModel>
    {
        private readonly IDistributedCache _cache;

        public UserController(IUserService service, IMapper map, IDistributedCache cache) : base(service, map)
        {
            _cache = cache;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<UserModel> models = await _service.Get();
                List<UserGetModel> getModels = _mapper.Map<List<UserGetModel>>(models);
                return Ok(getModels);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("Filtered")]
        [Authorize]
        public override async Task<IActionResult> GetFiltered(string? search, int? page, string? sortBy, bool isDesc)
        {
            Sorting sorting = new Sorting(sortBy, isDesc);
            Paging paging = new Paging(page);
            IEnumerable<UserModel> models = await _service.GetFiltered(search, paging, sorting);
            List<UserGetModel> getModel = _mapper.Map<List<UserGetModel>>(models);
            return Ok(getModel);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<UserPostModel>> Post(UserPostModel userPostModel)
        {
            try
            {
                if (userPostModel.Password != userPostModel.PasswordConfirm)
                {
                    return BadRequest("Passwords don't match!");
                }

                UserModel userModel = _mapper.Map<UserModel>(userPostModel);

                userModel.PasswordSalt = Hashing.GenerateSalt();
                userModel.PasswordHash = Hashing.GenerateHash(userModel.PasswordSalt, userPostModel.Password);

                await _service.Add(userModel);
                return CreatedAtAction(nameof(Get), userPostModel);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserRegisterModel>> Register(UserRegisterModel registerModel)
        {
            try
            {
                if (registerModel.Password != registerModel.PasswordConfirm)
                {
                    return BadRequest("Passwords don't match!");
                }

                UserModel userModel = _mapper.Map<UserModel>(registerModel);
                userModel.RoleId = 2;

                userModel.PasswordSalt = Hashing.GenerateSalt();
                userModel.PasswordHash = Hashing.GenerateHash(userModel.PasswordSalt, registerModel.Password);

                await _service.Add(userModel);

                return CreatedAtAction(nameof(Get), registerModel);

            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("EditAdmin/{id}")]
        [Authorize(Roles = "Admin")]
        public override async Task<ActionResult<UserPostModel>> Put(int id, UserPostModel userPostModel)
        {
            try
            {
                if (userPostModel.Password != userPostModel.PasswordConfirm)
                {
                    return BadRequest("Passwords don't match!");
                }

                UserModel userModel = _mapper.Map<UserModel>(userPostModel);

                if (!string.IsNullOrWhiteSpace(userPostModel.Password))
                {
                    userModel.PasswordSalt = Hashing.GenerateSalt();
                    userModel.PasswordHash = Hashing.GenerateHash(userModel.PasswordSalt, userPostModel.Password);
                }

                await _service.Edit(id, userModel);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPut("EditUser/{id}")]
        [Authorize]
        public async Task<ActionResult<UserPostModel>> Edit (int id, UserRegisterModel userEditModel)
        {
            try
            {
                if (userEditModel.Password != userEditModel.PasswordConfirm)
                {
                    return BadRequest("Passwords don't match!");
                }

                UserModel userModel = _mapper.Map<UserModel>(userEditModel);

                if (!string.IsNullOrWhiteSpace(userEditModel.Password))
                {
                    userModel.PasswordSalt = Hashing.GenerateSalt();
                    userModel.PasswordHash = Hashing.GenerateHash(userModel.PasswordSalt, userEditModel.Password);
                }

                await _service.Edit(id, userModel);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}
