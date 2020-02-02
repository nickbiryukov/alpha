using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Models.UserModels;
using Alpha.Reservation.App.Services.Contracts;
using Alpha.Reservation.Data;
using Alpha.Reservation.Data.Entities;
using Alpha.Reservation.Data.Repository;
using AutoMapper;

namespace Alpha.Reservation.App.Services
{
    public class UserService : RepositoryBase<User, DatabaseContext>, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(DatabaseContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(ShortUserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            return await AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(Guid id, ShortUserModel userModel)
        {
            var user = await GetAsync(id);

            user.Login = userModel.Login;
            user.Password = userModel.Password;
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.RoleId = userModel.RoleId;

            return await UpdateAsync(user);
        }
    }
}