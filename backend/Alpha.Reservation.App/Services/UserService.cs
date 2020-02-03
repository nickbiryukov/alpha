using System;
using System.Threading.Tasks;
using Alpha.Reservation.App.Hashing.Contracts;
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
        private readonly IHashProvider _hashProvider;

        public UserService(DatabaseContext context, IMapper mapper, IHashProvider hashProvider) : base(context)
        {
            _mapper = mapper;
            _hashProvider = hashProvider;
        }

        public async Task<User> AddUserAsync(ShortUserModel userModel)
        {
            userModel.Password = _hashProvider.CreateHash(userModel.Password);
            
            var user = _mapper.Map<User>(userModel);
            return await AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(Guid id, ShortUserModel userModel)
        {
            var user = await GetAsync(id);

            user.Login = userModel.Login;
            user.PasswordHash = _hashProvider.CreateHash(userModel.Password);
            user.Name = userModel.Name;
            user.Surname = userModel.Surname;
            user.RoleId = userModel.RoleId;

            return await UpdateAsync(user);
        }
        
        public bool Verife(string value, string valueHash)
        {
            return _hashProvider.Validate(value, valueHash);
        }
    }
}