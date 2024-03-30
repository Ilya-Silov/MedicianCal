using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApplication1.Config;
using WebApplication1.Data.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly MedicianContext _context = MedicianContext.Instance;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalCard>>> GetMedicalCards()
        {
            return await _context.Cards.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MedicalCard>> AddMedicalCard(MedicalCard card)
        {
            if (card.Birthdate.HasValue)
            {
                card.Birthdate = card.Birthdate?.ToUniversalTime();

            }
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMedicalCards), new { id = card.Id }, card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalCard(long id, MedicalCard card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }
            if (card.Birthdate.HasValue)
            {
                card.Birthdate = card.Birthdate?.ToUniversalTime();

            }

            try
            {
                var existingCard = await _context.Cards.FindAsync(id);

                if (existingCard == null)
                {
                    return NotFound();
                }

                _context.Entry(existingCard).CurrentValues.SetValues(card);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalCardExists(id))
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

        private bool MedicalCardExists(long id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
