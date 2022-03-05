#nullable disable

using GerenciaNf.Data.Contracts;
using GerenciaNf.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciaNf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INfContext _context;

        public NotaFiscalController(INfContext context)
        {
            _context = context;
        }

        // GET: api/NotaFiscal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetNotaFiscal()
        {
            return await _context.NotaFiscal.ToListAsync();
        }

        // GET: api/NotaFiscal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaFiscal>> GetNotaFiscal(int id)
        {
            var notaFiscal = await _context.NotaFiscal.FindAsync(id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return notaFiscal;
        }

        // PUT: api/NotaFiscal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaFiscal(int id, NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.Id)
            {
                return BadRequest();
            }

            _context.Entry(notaFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaFiscalExists(id))
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

        // POST: api/NotaFiscal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotaFiscal>> PostNotaFiscal(NotaFiscal notaFiscal)
        {
            _context.NotaFiscal.Add(notaFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaFiscal", new { id = notaFiscal.Id }, notaFiscal);
        }

        // DELETE: api/NotaFiscal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaFiscal(int id)
        {
            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            _context.NotaFiscal.Remove(notaFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaFiscalExists(int id)
        {
            return _context.NotaFiscal.Any(e => e.Id == id);
        }
    }
}