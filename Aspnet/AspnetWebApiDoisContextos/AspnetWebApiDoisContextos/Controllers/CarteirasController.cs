using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetWebApiDoisContextos.Data;
using AspnetWebApiDoisContextos.Models;

namespace AspnetWebApiDoisContextos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteirasController : ControllerBase
    {
        private readonly Contexto3 _context;

        public CarteirasController(Contexto3 context)
        {
            _context = context;
        }

        // GET: api/Carteiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carteira>>> GetCarteiras()
        {
          if (_context.Carteiras == null)
          {
              return NotFound();
          }
            return await _context.Carteiras.ToListAsync();
        }

        // GET: api/Carteiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carteira>> GetCarteira(int id)
        {
          if (_context.Carteiras == null)
          {
              return NotFound();
          }
            var carteira = await _context.Carteiras.FindAsync(id);

            if (carteira == null)
            {
                return NotFound();
            }

            return carteira;
        }

        // PUT: api/Carteiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarteira(int id, Carteira carteira)
        {
            if (id != carteira.Id)
            {
                return BadRequest();
            }

            _context.Entry(carteira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteiraExists(id))
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

        // POST: api/Carteiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carteira>> PostCarteira(Carteira carteira)
        {
          if (_context.Carteiras == null)
          {
              return Problem("Entity set 'Contexto3.Carteiras'  is null.");
          }
            _context.Carteiras.Add(carteira);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarteiraExists(carteira.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarteira", new { id = carteira.Id }, carteira);
        }

        // DELETE: api/Carteiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarteira(int id)
        {
            if (_context.Carteiras == null)
            {
                return NotFound();
            }
            var carteira = await _context.Carteiras.FindAsync(id);
            if (carteira == null)
            {
                return NotFound();
            }

            _context.Carteiras.Remove(carteira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarteiraExists(int id)
        {
            return (_context.Carteiras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
