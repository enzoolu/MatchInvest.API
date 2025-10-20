using MatchInvest.API.Data;
using MatchInvest.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchInvest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssessorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Assessors (Read All)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assessor>>> GetAssessors()
        {
            return await _context.Assessors.ToListAsync();
        }

        // GET: api/Assessors/5 (Read by ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Assessor>> GetAssessor(int id)
        {
            var assessor = await _context.Assessors.FindAsync(id);

            if (assessor == null)
            {
                return NotFound();
            }

            return assessor;
        }

        // GET: api/Assessors/search?especializacao=RendaFixa
        // --- REQUISITO: PESQUISAS COM LINQ ---
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Assessor>>> SearchAssessors([FromQuery] string especializacao)
        {
            if (string.IsNullOrWhiteSpace(especializacao))
            {
                return await _context.Assessors.ToListAsync();
            }

            // Consulta LINQ: Filtra assessores cuja especialização contenha o termo de busca (case-insensitive)
            var assessores = await _context.Assessors
                .Where(a => a.Especializacao.ToLower().Contains(especializacao.ToLower()))
                .ToListAsync();

            if (!assessores.Any())
            {
                return NotFound($"Nenhum assessor encontrado com especialização em '{especializacao}'.");
            }

            return assessores;
        }

        // POST: api/Assessors (Create)
        [HttpPost]
        public async Task<ActionResult<Assessor>> PostAssessor(Assessor assessor)
        {
            _context.Assessors.Add(assessor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssessor), new { id = assessor.Id }, assessor);
        }

        // PUT: api/Assessors/5 (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessor(int id, Assessor assessor)
        {
            if (id != assessor.Id)
            {
                return BadRequest();
            }

            _context.Entry(assessor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Assessors.Any(e => e.Id == id))
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

        // DELETE: api/Assessors/5 (Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessor(int id)
        {
            var assessor = await _context.Assessors.FindAsync(id);
            if (assessor == null)
            {
                return NotFound();
            }

            _context.Assessors.Remove(assessor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}