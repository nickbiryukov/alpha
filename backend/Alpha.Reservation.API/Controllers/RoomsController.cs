using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.RoomModels;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [Authorize(Roles = "Office manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<RoomModel>>(await _roomService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<RoomModel> Get(Guid id)
        {
            return _mapper.Map<RoomModel>(await _roomService.GetAsync(id));
        }

        [HttpPost]
        public async Task<RoomModel> Post([FromBody] ShortRoomModel roomModel)
        {
            return _mapper.Map<RoomModel>(await _roomService.AddRoomAsync(roomModel));
        }

        [HttpPut("{id}")]
        public async Task<RoomModel> Put(Guid id, [FromBody] ShortRoomModel roomModel)
        {
            return _mapper.Map<RoomModel>(await _roomService.UpdateRoomAsync(id, roomModel));
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _roomService.DeleteAsync(id);
        }
    }
}