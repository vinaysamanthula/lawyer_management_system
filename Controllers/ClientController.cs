using Microsoft.AspNetCore.Mvc;
using lawyer_management_system.Data;
using lawyer_management_system.Models;

namespace lawyer_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }
    }
}
