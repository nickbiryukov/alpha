using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.ReservationModels;
using Alpha.Reservation.App.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.Reservation.API.Controllers
{
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
        public async Task<IEnumerable<ReservationModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ReservationModel>>(await _reservationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ReservationWithDetailsModel> Get(Guid id)
        {
            return _mapper.Map<ReservationWithDetailsModel>(await _reservationService.GetWithDetails(id));
        }

        [HttpPost]
        public async Task<ReservationModel> Post([FromBody] CreateReservationModel reservationModel)
        {
            return _mapper.Map<ReservationModel>(await _reservationService.AddReservationAsync(reservationModel));
        }

        [HttpPut("{id}")]
        public async Task<ReservationModel> Put(Guid id, [FromBody] ShortReservationModel reservationModel)
        {
            return _mapper.Map<ReservationModel>(await _reservationService.UpdateReservationAsync(id, reservationModel));
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _reservationService.DeleteAsync(id);
        }
    }
}