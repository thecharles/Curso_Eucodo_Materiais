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
    public class MesasController : ControllerBase
    {
        private readonly LanchoneteContext _context;

        public MesasController(LanchoneteContext context)
        {
            _context = context;
        }

        // GET: api/Mesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
          if (_context.Mesas == null)
          {
              return NotFound();
          }
            return await _context.Mesas.ToListAsync();
        }

        // GET: api/Mesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
          if (_context.Mesas == null)
          {
              return NotFound();
          }
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return mesa;
        }

        // PUT: api/Mesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, Mesa mesa)
        {
            if (id != mesa.Id)
            {
                return BadRequest();
            }

            _context.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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

        // POST: api/Mesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(Mesa mesa)
        {
          if (_context.Mesas == null)
          {
              return Problem("Entity set 'LanchoneteContext.Mesas'  is null.");
          }
            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesa", new { id = mesa.Id }, mesa);
        }

        // DELETE: api/Mesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            if (_context.Mesas == null)
            {
                return NotFound();
            }
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExists(int id)
        {
            return (_context.Mesas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
