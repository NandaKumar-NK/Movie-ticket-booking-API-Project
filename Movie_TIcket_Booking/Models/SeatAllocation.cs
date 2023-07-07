using System.ComponentModel.DataAnnotations;

namespace Movie_TIcket_Booking.Models
{
    public class SeatAllocation
    {
        [Key]
        public int SeatNo { get; set; }
        public DateTime ShowTime { get; set; }

        public string SeatStatus { get; set; } = string.Empty;

        public ScreenDetails? ScreenDetails { get; set; }
        public virtual ICollection<BookingDeatils>? BookingDeatil { get; set; }
    }
}
