using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanchoneteAPI.Data;
using LanchoneteAPI.Models;

namespace LanchoneteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasPedidosController : ControllerBase
    {
        private readonly LanchoneteContext _context;

        public MesasPedidosController(LanchoneteContext context)
        {
            _context = context;
        }

        // GET: api/MesasPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesasPedido>>> GetMesasPedidos()
        {
          if (_context.MesasPedidos == null)
          {
              return NotFound();
          }
            return await _context.MesasPedidos.ToListAsync();
        }

        // GET: api/MesasPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MesasPedido>> GetMesasPedido(int id)
        {
          if (_context.MesasPedidos == null)
          {
              return NotFound();
          }
            var mesasPedido = await _context.MesasPedidos.FindAsync(id);

            if (mesasPedido == null)
            {
                return NotFound();
            }

            return mesasPedido;
        }

        // PUT: api/MesasPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesasPedido(int id, MesasPedido mesasPedido)
        {
            if (id != mesasPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(mesasPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesasPedidoExists(id))
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

        // POST: api/MesasPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MesasPedido>> PostMesasPedido(MesasPedido mesasPedido)
        {
          if (_context.MesasPedidos == null)
          {
              return Problem("Entity set 'LanchoneteContext.MesasPedidos'  is null.");
          }
            _context.MesasPedidos.Add(mesasPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesasPedido", new { id = mesasPedido.Id }, mesasPedido);
        }

        // DELETE: api/MesasPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesasPedido(int id)
        {
            if (_context.MesasPedidos == null)
            {
                return NotFound();
            }
            var mesasPedido = await _context.MesasPedidos.FindAsync(id);
            if (mesasPedido == null)
            {
                return NotFound();
            }

            _context.MesasPedidos.Remove(mesasPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesasPedidoExists(int id)
        {
            return (_context.MesasPedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
