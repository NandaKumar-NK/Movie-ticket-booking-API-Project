using System.ComponentModel.DataAnnotations;

namespace Movie_TIcket_Booking.Models
{
    public class ScreenDetails
    {

        [Key]
        public int ScreenId { get; set; }
        public string ScreenName { get; set; } = string.Empty;
      
        public int? TotalSeatCount { get; set; }
        public MovieDetails? MovieDetails { get; set; }
        public  ICollection<SeatAllocation> SeatAllocatioons { get; set; }

    }
}
