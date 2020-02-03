using System;
using Alpha.Reservation.Data.Entities.Enums;

namespace Alpha.Reservation.App.Models.UserModels
{
    public class UserModel
    {
        public Guid Id { get; set; }
        
        public string Login { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public ERole RoleId { get; set; }
    }
}