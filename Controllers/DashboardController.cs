using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lawyer_management_system.Data;
using Microsoft.EntityFrameworkCore;

namespace lawyer_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var today = DateTime.Today;
            var next7Days = today.AddDays(7);

            var totalClients = await _context.Clients.CountAsync();
            var totalCases = await _context.Cases.CountAsync();

            var upcomingRenewals = await _context.Cases
                .CountAsync(c => c.RenewalDate >= today && c.RenewalDate <= next7Days);

            var pendingReminders = await _context.Cases
                .CountAsync(c => c.ReminderSent == false);

            var completedReminders = await _context.Cases
                .CountAsync(c => c.ReminderSent == true);

            return Ok(new
            {
                totalClients,
                totalCases,
                upcomingRenewals,
                pendingReminders,
                completedReminders
            });
        }
    }
}
