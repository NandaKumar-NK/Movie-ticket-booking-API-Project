using System.ComponentModel.DataAnnotations;

namespace Movie_TIcket_Booking.Models
{
    public class MovieDetails
    {
        [Key]
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? MovieDescription { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public  ICollection<ScreenDetails>? ScreenDetails { get; set; }
        public  ICollection<BookingDeatils>? Deatils { get; set; }
        


    }
}
