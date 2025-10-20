using MatchInvest.API.Data;
using MatchInvest.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvestorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Investors (Read All)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investor>>> GetInvestors()
        {
            return await _context.Investors.ToListAsync();
        }

        // GET: api/Investors/5 (Read by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Investor>> GetInvestor(int id)
        {
            var investor = await _context.Investors.FindAsync(id);

            if (investor == null)
            {
                return NotFound();
            }

            return investor;
        }

        // POST: api/Investors (Create)
        [HttpPost]
        public async Task<ActionResult<Investor>> PostInvestor(Investor investor)
        {
            _context.Investors.Add(investor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvestor), new { id = investor.Id }, investor);
        }

        // PUT: api/Investors/5 (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestor(int id, Investor investor)
        {
            if (id != investor.Id)
            {
                return BadRequest();
            }

            _context.Entry(investor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Investors.Any(e => e.Id == id))
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

        // DELETE: api/Investors/5 (Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestor(int id)
        {
            var investor = await _context.Investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound();
            }

            _context.Investors.Remove(investor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}