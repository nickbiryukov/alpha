using System.ComponentModel.DataAnnotations;

namespace Alpha.Reservation.App.Models.AccountModels
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}