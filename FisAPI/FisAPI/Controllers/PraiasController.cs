using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisAPI.Data;
using FisAPI.Models;

namespace FisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraiasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PraiasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Praias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Praia>>> GetPRAIAS()
        {
            return await _context.PRAIAS.ToListAsync();
        }

        // GET: api/Praias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Praia>> GetPraia(int id)
        {
            var praia = await _context.PRAIAS.FindAsync(id);

            if (praia == null)
            {
                return NotFound();
            }

            return praia;
        }

        // PUT: api/Praias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPraia(int id, Praia praia)
        {
            if (id != praia.Id)
            {
                return BadRequest();
            }

            _context.Entry(praia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PraiaExists(id))
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

        // POST: api/Praias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Praia>> PostPraia(Praia praia)
        {
            _context.PRAIAS.Add(praia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPraia", new { id = praia.Id }, praia);
        }

        // DELETE: api/Praias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePraia(int id)
        {
            var praia = await _context.PRAIAS.FindAsync(id);
            if (praia == null)
            {
                return NotFound();
            }

            _context.PRAIAS.Remove(praia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PraiaExists(int id)
        {
            return _context.PRAIAS.Any(e => e.Id == id);
        }
    }
}
