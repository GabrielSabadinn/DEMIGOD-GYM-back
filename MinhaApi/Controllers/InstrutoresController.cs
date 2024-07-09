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
    public class InstrutoresController : ControllerBase
    {
        private readonly MinhaApiContext _context;

        public InstrutoresController(MinhaApiContext context)
        {
            _context = context;
        }

        // GET: api/Instrutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrutor>>> GetInstrutores()
        {
            return await _context.Instrutores.ToListAsync();
        }

        // GET: api/Instrutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrutor>> GetInstrutor(int id)
        {
            var instrutor = await _context.Instrutores.FindAsync(id);

            if (instrutor == null)
            {
                return NotFound();
            }

            return instrutor;
        }

        // PUT: api/Instrutores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrutor(int id, Instrutor instrutor)
        {
            if (id != instrutor.Id)
            {
                return BadRequest();
            }

            _context.Entry(instrutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrutorExists(id))
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

        // POST: api/Instrutores
        [HttpPost]
        public async Task<ActionResult<Instrutor>> PostInstrutor(Instrutor instrutor)
        {
            _context.Instrutores.Add(instrutor);
            await _context.SaveChangesAsync();

            var mensagem = $"Instrutor {instrutor.Nome} cadastrado com sucesso.";

            return CreatedAtAction("GetInstrutor", new { id = instrutor.Id }, new { Mensagem = mensagem, Instrutor = instrutor });
        }

        // DELETE: api/Instrutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrutor(int id)
        {
            var instrutor = await _context.Instrutores.FindAsync(id);
            if (instrutor == null)
            {
                return NotFound();
            }

            _context.Instrutores.Remove(instrutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrutorExists(int id)
        {
            return _context.Instrutores.Any(e => e.Id == id);
        }
    }
}
