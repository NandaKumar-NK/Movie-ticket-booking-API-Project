using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_TIcket_Booking.Models;

namespace Movie_TIcket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDeatilsController : ControllerBase
    {
        private readonly MovieTicketContext _context;

        public BookingDeatilsController(MovieTicketContext context)
        {
            _context = context;
        }

        // GET: api/BookingDeatils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDeatils>>> GetBookingDeatil()
        {
          if (_context.BookingDeatil == null)
          {
              return NotFound();
          }
            return await _context.BookingDeatil.ToListAsync();
        }

        // GET: api/BookingDeatils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDeatils>> GetBookingDeatils(int id)
        {
          if (_context.BookingDeatil == null)
          {
              return NotFound();
          }
            var bookingDeatils = await _context.BookingDeatil.FindAsync(id);

            if (bookingDeatils == null)
            {
                return NotFound();
            }

            return bookingDeatils;
        }

        // PUT: api/BookingDeatils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDeatils(int id, BookingDeatils bookingDeatils)
        {
            if (id != bookingDeatils.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDeatils).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDeatilsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingDeatils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDeatils>> PostBookingDeatils(BookingDeatils bookingDeatils)
        {
          if (_context.BookingDeatil == null)
          {
              return Problem("Entity set 'MovieTicketContext.BookingDeatil'  is null.");
          }
            _context.BookingDeatil.Add(bookingDeatils);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDeatils", new { id = bookingDeatils.BookingId }, bookingDeatils);
        }

        // DELETE: api/BookingDeatils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDeatils(int id)
        {
            if (_context.BookingDeatil == null)
            {
                return NotFound();
            }
            var bookingDeatils = await _context.BookingDeatil.FindAsync(id);
            if (bookingDeatils == null)
            {
                return NotFound();
            }

            _context.BookingDeatil.Remove(bookingDeatils);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDeatilsExists(int id)
        {
            return (_context.BookingDeatil?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
