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
    public class ScreenDetailsController : ControllerBase
    {
        private readonly MovieTicketContext _context;

        public ScreenDetailsController(MovieTicketContext context)
        {
            _context = context;
        }

        // GET: api/ScreenDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScreenDetails>>> GetScreenDetail()
        {
          if (_context.ScreenDetail == null)
          {
              return NotFound();
          }
            return await _context.ScreenDetail.ToListAsync();
        }

        // GET: api/ScreenDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScreenDetails>> GetScreenDetails(int id)
        {
          if (_context.ScreenDetail == null)
          {
              return NotFound();
          }
            var screenDetails = await _context.ScreenDetail.FindAsync(id);

            if (screenDetails == null)
            {
                return NotFound();
            }

            return screenDetails;
        }

        // PUT: api/ScreenDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreenDetails(int id, ScreenDetails screenDetails)
        {
            if (id != screenDetails.ScreenId)
            {
                return BadRequest();
            }

            _context.Entry(screenDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreenDetailsExists(id))
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

        // POST: api/ScreenDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScreenDetails>> PostScreenDetails(ScreenDetails screenDetails)
        {
          if (_context.ScreenDetail == null)
          {
              return Problem("Entity set 'MovieTicketContext.ScreenDetail'  is null.");
          }
            _context.ScreenDetail.Add(screenDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScreenDetails", new { id = screenDetails.ScreenId }, screenDetails);
        }

        // DELETE: api/ScreenDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreenDetails(int id)
        {
            if (_context.ScreenDetail == null)
            {
                return NotFound();
            }
            var screenDetails = await _context.ScreenDetail.FindAsync(id);
            if (screenDetails == null)
            {
                return NotFound();
            }

            _context.ScreenDetail.Remove(screenDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScreenDetailsExists(int id)
        {
            return (_context.ScreenDetail?.Any(e => e.ScreenId == id)).GetValueOrDefault();
        }
    }
}
