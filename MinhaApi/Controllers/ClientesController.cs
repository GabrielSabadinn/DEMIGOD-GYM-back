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
    public class ClientesController : ControllerBase
    {
        private readonly MinhaApiContext _context;

        public ClientesController(MinhaApiContext context)
        {
            _context = context;
        }

        // GET: api/Clientes/getzao
        [HttpGet("getzao")]
        public async Task<ActionResult<object>> GetTudo()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var instrutores = await _context.Instrutores.ToListAsync();
            var planos = await _context.Planos.ToListAsync();
            var modalidades = await _context.Modalidades.ToListAsync();
            var avaliacoesFisicas = await _context.AvaliacoesFisicas.ToListAsync();
            var maquinas = await _context.Maquinas.ToListAsync();
            var filiais = await _context.Filiais.ToListAsync();
            var contas = await _context.Contas.ToListAsync();

            return Ok(new
            {
                Clientes = clientes,
                Instrutores = instrutores,
                Planos = planos,
                Modalidades = modalidades,
                AvaliacoesFisicas = avaliacoesFisicas,
                Maquinas = maquinas,
                Filiais = filiais,
                Contas = contas
            });
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            // Verifica se o Plano existe
            var plano = await _context.Planos.FindAsync(cliente.PlanoId);
            if (plano == null)
            {
                return BadRequest("Plano não encontrado");
            }

            // Se o Plano existe, adiciona o Cliente
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
