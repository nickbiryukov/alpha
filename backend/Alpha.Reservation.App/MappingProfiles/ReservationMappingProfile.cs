using Alpha.Reservation.App.Models.ReservationModels;
using AutoMapper;

namespace Alpha.Reservation.App.MappingProfiles
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Data.Entities.Reservation, ReservationWithDetailsModel>()
                .ForMember(a => a.Room, a =>
                    a.MapFrom(b => b.Room))
                .ForMember(a => a.User, a =>
                    a.MapFrom(b => b.User));

            CreateMap<ReservationWithDetailsModel, Data.Entities.Reservation>()
                .ForMember(a => a.Room, a =>
                    a.MapFrom(b => b.Room))
                .ForMember(a => a.User, a =>
                    a.MapFrom(b => b.User));

            CreateMap<Data.Entities.Reservation, ReservationModel>();

            CreateMap<ReservationModel, Data.Entities.Reservation>();

            CreateMap<CreateReservationModel, Data.Entities.Reservation>();

            CreateMap<ShortReservationModel, Data.Entities.Reservation>();
            
            CreateMap<Data.Entities.Reservation, ShortReservationModel>();
        }
    }
}