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
    public class AvaliacoesFisicasController : ControllerBase
    {
        private readonly MinhaApiContext _context;

        public AvaliacoesFisicasController(MinhaApiContext context)
        {
            _context = context;
        }

        // GET: api/AvaliacoesFisicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoFisica>>> GetAvaliacoesFisicas()
        
        {
            var queryable = _context.AvaliacoesFisicas.AsQueryable();
            queryable = queryable.Include(X => X.Cliente);
            queryable = queryable.Include(X => X.Instrutor);
            return await queryable.ToListAsync();
        }

        // GET: api/AvaliacoesFisicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoFisica>> GetAvaliacaoFisica(int id)
        {
            var avaliacaoFisica = await _context.AvaliacoesFisicas.FindAsync(id);

            if (avaliacaoFisica == null)
            {
                return NotFound();
            }

            return avaliacaoFisica;
        }

        // PUT: api/AvaliacoesFisicas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvaliacaoFisica(int id, AvaliacaoFisica avaliacaoFisica)
        {
            if (id != avaliacaoFisica.Id)
            {
                return BadRequest();
            }

            _context.Entry(avaliacaoFisica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoFisicaExists(id))
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

        // POST: api/AvaliacoesFisicas
        [HttpPost]
        public async Task<ActionResult<AvaliacaoFisica>> PostAvaliacaoFisica(AvaliacaoFisica avaliacaoFisica)
        {
            _context.AvaliacoesFisicas.Add(avaliacaoFisica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvaliacaoFisica", new { id = avaliacaoFisica.Id }, avaliacaoFisica);
        }

        // DELETE: api/AvaliacoesFisicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacaoFisica(int id)
        {
            var avaliacaoFisica = await _context.AvaliacoesFisicas.FindAsync(id);
            if (avaliacaoFisica == null)
            {
                return NotFound();
            }

            _context.AvaliacoesFisicas.Remove(avaliacaoFisica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvaliacaoFisicaExists(int id)
        {
            return _context.AvaliacoesFisicas.Any(e => e.Id == id);
        }
    }
}
