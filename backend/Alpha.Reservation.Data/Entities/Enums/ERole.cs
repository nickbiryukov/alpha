using System.ComponentModel;

namespace Alpha.Reservation.Data.Entities.Enums
{
    public enum ERole
    {
        [Description("Office Manager")]
        OfficeManager = 1,
        
        [Description("Employee")]
        Employee = 2
    }
}