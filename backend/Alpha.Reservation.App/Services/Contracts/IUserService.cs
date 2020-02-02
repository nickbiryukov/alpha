using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.UserModels;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Repository.Contracts;

namespace Alpha.Reservation.App.Services.Contracts
{
    public interface IUserService : IRepositoryBase<User>
    {
        Task<User> AddUserAsync(ShortUserModel userModel);

        Task<User> UpdateUserAsync(Guid id, ShortUserModel userModel);
    }
}