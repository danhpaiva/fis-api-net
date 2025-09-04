using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisAPI.Data;
using FisAPI.Models;

namespace FisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoDeSurfsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventoDeSurfsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EventoDeSurfs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDeSurf>>> GetEVENTOS()
        {
            return await _context.EVENTOS.ToListAsync();
        }

        // GET: api/EventoDeSurfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDeSurf>> GetEventoDeSurf(int id)
        {
            var eventoDeSurf = await _context.EVENTOS.FindAsync(id);

            if (eventoDeSurf == null)
            {
                return NotFound();
            }

            return eventoDeSurf;
        }

        // PUT: api/EventoDeSurfs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventoDeSurf(int id, EventoDeSurf eventoDeSurf)
        {
            if (id != eventoDeSurf.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventoDeSurf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoDeSurfExists(id))
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

        // POST: api/EventoDeSurfs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoDeSurf>> PostEventoDeSurf(EventoDeSurf eventoDeSurf)
        {

            // Validação de Data (lógica de negócio)
            if (eventoDeSurf.Data <= DateTime.Now)
            {
                return BadRequest("A data do evento deve ser futura.");
            }

            _context.EVENTOS.Add(eventoDeSurf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventoDeSurf", new { id = eventoDeSurf.Id }, eventoDeSurf);
        }

        // DELETE: api/EventoDeSurfs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoDeSurf(int id)
        {
            var eventoDeSurf = await _context.EVENTOS.FindAsync(id);
            if (eventoDeSurf == null)
            {
                return NotFound();
            }

            _context.EVENTOS.Remove(eventoDeSurf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventoDeSurfExists(int id)
        {
            return _context.EVENTOS.Any(e => e.Id == id);
        }
    }
}
