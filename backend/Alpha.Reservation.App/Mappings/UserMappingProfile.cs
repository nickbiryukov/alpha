using Alpha.Reservation.App.Models.UserModels;
using Alpha.Reservation.Data.Entities;
using AutoMapper;

namespace Alpha.Reservation.App.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>();
            
            CreateMap<UserModel, User>();

            CreateMap<ShortUserModel, User>()
                .ForMember(a => a.PasswordHash, a =>
                    a.MapFrom(b => b.Password));
        }
    }
}