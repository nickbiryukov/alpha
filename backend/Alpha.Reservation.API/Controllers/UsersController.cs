using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.UserModels;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [Authorize(Roles = "Office Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("ByLogin/{login}")]
        public async Task<UserModel> GetByLogin(string login)
        {
            return _mapper.Map<UserModel>(await _userService.GetByLogin(login));
        }
        
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<UserModel> Get(Guid id)
        {
            return _mapper.Map<UserModel>(await _userService.GetAsync(id));
        }

        [HttpPost]
        public async Task<UserModel> Post([FromBody] ShortUserModel userModel)
        {
            return _mapper.Map<UserModel>(await _userService.AddUserAsync(userModel));
        }

        [HttpPut("{id}")]
        public async Task<UserModel> Put(Guid id, [FromBody] ShortUserModel userModel)
        {
            return _mapper.Map<UserModel>(await _userService.UpdateUserAsync(id, userModel));
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}