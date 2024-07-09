using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliaisController : ControllerBase
    {
        private readonly MinhaApiContext _context;

        public FiliaisController(MinhaApiContext context)
        {
            _context = context;
        }

        // GET: api/Filiais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filial>>> GetFiliais()
        {
            return await _context.Filiais.ToListAsync();
        }

        // GET: api/Filiais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filial>> GetFilial(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);

            if (filial == null)
            {
                return NotFound();
            }

            return filial;
        }

        // PUT: api/Filiais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilial(int id, Filial filial)
        {
            if (id != filial.Id)
            {
                return BadRequest();
            }

            _context.Entry(filial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilialExists(id))
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

        // POST: api/Filiais
        [HttpPost]
        public async Task<ActionResult<Filial>> PostFilial(Filial filial)
        {
            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilial", new { id = filial.Id }, filial);
        }

        // DELETE: api/Filiais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilial(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilialExists(int id)
        {
            return _context.Filiais.Any(e => e.Id == id);
        }
    }
}
