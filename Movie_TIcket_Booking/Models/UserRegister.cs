using System.ComponentModel.DataAnnotations;

namespace Movie_TIcket_Booking.Models
{
    public class UserRegister
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<BookingDeatils>? BookingDeatil { get; set; }
    }
}
