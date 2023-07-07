using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Movie_TIcket_Booking.Models
{
    public class BookingDeatils
    {
        [Key]
        public int BookingId { get; set;}
        public DateTime? BookingDate { get; set;}
       
        public decimal Fare { get; set;}
        public MovieDetails? MovieDetails { get; set;}
       
        public UserRegister? UserRegister { get; set;}
        public ScreenDetails? ScreenDetails { get; set;}
        public SeatAllocation? SeatAllocatioon { get; set;}
    }
}
