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
    public class ModalidadesController : ControllerBase
    {
        private readonly MinhaApiContext _context;

        public ModalidadesController(MinhaApiContext context)
        {
            _context = context;
        }

        // GET: api/Modalidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modalidade>>> GetModalidades()
        {
            return await _context.Modalidades.ToListAsync();
        }

        // GET: api/Modalidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modalidade>> GetModalidade(int id)
        {
            var modalidade = await _context.Modalidades.FindAsync(id);

            if (modalidade == null)
            {
                return NotFound();
            }

            return modalidade;
        }

        // PUT: api/Modalidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModalidade(int id, Modalidade modalidade)
        {
            if (id != modalidade.Id)
            {
                return BadRequest();
            }

            _context.Entry(modalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalidadeExists(id))
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

        
        // POST: api/Modalidades
        [HttpPost]
        public async Task<ActionResult<Modalidade>> PostModalidade(Modalidade modalidade)
        {
            // Verifica se o Instrutor existe
            var instrutor = await _context.Instrutores.FindAsync(modalidade.InstrutorId);
            if (instrutor == null)
            {
                return BadRequest("Instrutor não encontrado");
            }

            // Se o Instrutor existe, adiciona a Modalidade
            _context.Modalidades.Add(modalidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModalidade", new { id = modalidade.Id }, modalidade);
        }


        // DELETE: api/Modalidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModalidade(int id)
        {
            var modalidade = await _context.Modalidades.FindAsync(id);
            if (modalidade == null)
            {
                return NotFound();
            }

            _context.Modalidades.Remove(modalidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModalidadeExists(int id)
        {
            return _context.Modalidades.Any(e => e.Id == id);
        }
    }
}
