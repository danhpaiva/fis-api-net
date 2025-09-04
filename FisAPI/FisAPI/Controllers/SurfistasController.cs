using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisAPI.Data;
using FisAPI.Models;

namespace FisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurfistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SurfistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Surfistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surfista>>> GetSURFISTAS()
        {
            return await _context.SURFISTAS.ToListAsync();
        }

        // GET: api/Surfistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surfista>> GetSurfista(int id)
        {
            var surfista = await _context.SURFISTAS.FindAsync(id);

            if (surfista == null)
            {
                return NotFound();
            }

            return surfista;
        }

        // PUT: api/Surfistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurfista(int id, Surfista surfista)
        {
            if (id != surfista.Id)
            {
                return BadRequest();
            }

            _context.Entry(surfista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurfistaExists(id))
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

        // POST: api/Surfistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Surfista>> PostSurfista(Surfista surfista)
        {
            _context.SURFISTAS.Add(surfista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurfista", new { id = surfista.Id }, surfista);
        }

        // DELETE: api/Surfistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurfista(int id)
        {
            var surfista = await _context.SURFISTAS.FindAsync(id);
            if (surfista == null)
            {
                return NotFound();
            }

            _context.SURFISTAS.Remove(surfista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurfistaExists(int id)
        {
            return _context.SURFISTAS.Any(e => e.Id == id);
        }
    }
}
