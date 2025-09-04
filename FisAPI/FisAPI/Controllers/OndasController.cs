using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FisAPI.Data;
using FisAPI.Models;

namespace FisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OndasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OndasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ondas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Onda>>> GetONDAS()
        {
            return await _context.ONDAS.ToListAsync();
        }

        // GET: api/Ondas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Onda>> GetOnda(int id)
        {
            var onda = await _context.ONDAS.FindAsync(id);

            if (onda == null)
            {
                return NotFound();
            }

            return onda;
        }

        // PUT: api/Ondas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnda(int id, Onda onda)
        {
            if (id != onda.Id)
            {
                return BadRequest();
            }

            _context.Entry(onda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OndaExists(id))
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

        // POST: api/Ondas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Onda>> PostOnda(Onda onda)
        {
            _context.ONDAS.Add(onda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnda", new { id = onda.Id }, onda);
        }

        // DELETE: api/Ondas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnda(int id)
        {
            var onda = await _context.ONDAS.FindAsync(id);
            if (onda == null)
            {
                return NotFound();
            }

            _context.ONDAS.Remove(onda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OndaExists(int id)
        {
            return _context.ONDAS.Any(e => e.Id == id);
        }
    }
}
