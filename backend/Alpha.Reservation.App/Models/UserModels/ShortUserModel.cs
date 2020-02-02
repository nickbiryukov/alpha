using Alpha.Reservation.Data.Entities.Enums;

namespace Alpha.Reservation.App.Models.UserModels
{
    public class ShortUserModel
    {
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public ERole RoleId { get; set; }
    }
}