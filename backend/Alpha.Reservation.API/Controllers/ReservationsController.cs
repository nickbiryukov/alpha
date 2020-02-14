using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.ReservationModels;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReservationModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ReservationModel>>(_reservationService.GetAllWithOrder());
        }

        [HttpGet("{id}")]
        public async Task<ReservationWithDetailsModel> Get(Guid id)
        {
            return _mapper.Map<ReservationWithDetailsModel>(await _reservationService.GetWithDetailsAsync(id));
        }

        [HttpPost]
        public async Task<ReservationModel> Post([FromBody] CreateReservationModel reservationModel)
        {
            return _mapper.Map<ReservationModel>(await _reservationService.AddReservationAsync(reservationModel));
        }

        [Authorize(Roles = "Office Manager")]
        [HttpPut("{id}")]
        public async Task<ReservationModel> Put([FromRoute] Guid id, [FromBody] ShortReservationModel reservationModel)
        {
            return _mapper.Map<ReservationModel>(await _reservationService.UpdateReservationAsync(id, reservationModel));
        }
        
        [Authorize(Roles = "Office Manager")]
        [HttpPut("UpdateConfirmation/{id}")]
        public async Task<ReservationModel> UpdateConfirmation([FromRoute] Guid id, [FromBody] bool confirmation)
        {
            return _mapper.Map<ReservationModel>(await _reservationService.UpdateConfirmationAsync(id, confirmation));
        }

        [Authorize(Roles = "Office Manager")]
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await _reservationService.DeleteAsync(id);
        }
    }
}