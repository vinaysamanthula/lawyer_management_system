using lawyer_management_system.Data;
using lawyer_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lawyer_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddCase(LegalCase legalCase)
        {
            // Check if client exists
            var clientExists = await _context.Clients.FindAsync(legalCase.ClientId);

            if (clientExists == null)
            {
                return BadRequest("Client does not exist");
            }

            _context.Cases.Add(legalCase);
            await _context.SaveChangesAsync();

            return Ok(legalCase);
        }
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingRenewals()
        {
            var today = DateTime.Today;
            var next7Days = today.AddDays(7);

            var upcomingCases = await _context.Cases
                .Where(c => c.RenewalDate >= today &&
                            c.RenewalDate <= next7Days &&
                            c.ReminderSent == false) // ✅ only pending
                .OrderBy(c => c.RenewalDate) // ✅ sorted
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    c.RenewalDate,
                    DaysLeft = (c.RenewalDate - today).Days,
                    c.ClientId
                })
                .ToListAsync();

            return Ok(upcomingCases);
        }
    }
}
