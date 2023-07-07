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
    public class SeatAllocationsController : ControllerBase
    {
        private readonly MovieTicketContext _context;

        public SeatAllocationsController(MovieTicketContext context)
        {
            _context = context;
        }

        // GET: api/SeatAllocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatAllocation>>> GetSeatAllocation()
        {
          if (_context.SeatAllocation == null)
          {
              return NotFound();
          }
            return await _context.SeatAllocation.ToListAsync();
        }

        // GET: api/SeatAllocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatAllocation>> GetSeatAllocation(int id)
        {
          if (_context.SeatAllocation == null)
          {
              return NotFound();
          }
            var seatAllocation = await _context.SeatAllocation.FindAsync(id);

            if (seatAllocation == null)
            {
                return NotFound();
            }

            return seatAllocation;
        }

        // PUT: api/SeatAllocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatAllocation(int id, SeatAllocation seatAllocation)
        {
            if (id != seatAllocation.SeatNo)
            {
                return BadRequest();
            }

            _context.Entry(seatAllocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatAllocationExists(id))
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

        // POST: api/SeatAllocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatAllocation>> PostSeatAllocation(SeatAllocation seatAllocation)
        {
          if (_context.SeatAllocation == null)
          {
              return Problem("Entity set 'MovieTicketContext.SeatAllocation'  is null.");
          }
            _context.SeatAllocation.Add(seatAllocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeatAllocation", new { id = seatAllocation.SeatNo }, seatAllocation);
        }

        // DELETE: api/SeatAllocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatAllocation(int id)
        {
            if (_context.SeatAllocation == null)
            {
                return NotFound();
            }
            var seatAllocation = await _context.SeatAllocation.FindAsync(id);
            if (seatAllocation == null)
            {
                return NotFound();
            }

            _context.SeatAllocation.Remove(seatAllocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatAllocationExists(int id)
        {
            return (_context.SeatAllocation?.Any(e => e.SeatNo == id)).GetValueOrDefault();
        }
    }
}
