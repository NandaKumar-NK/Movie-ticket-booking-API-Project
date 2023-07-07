using Microsoft.EntityFrameworkCore;

namespace Movie_TIcket_Booking.Models
{
    public class MovieTicketContext:DbContext
    {
        public MovieTicketContext(DbContextOptions<MovieTicketContext> options) : base(options)
        {

        }
        public  DbSet<MovieDetails> MovieDetail { get; set; }
        public DbSet<ScreenDetails> ScreenDetail { get; set; }
        public DbSet<SeatAllocation> SeatAllocation { get; set; }
        public DbSet<BookingDeatils> BookingDeatil { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRegister> userRegister { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
