
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using lawyer_management_system.Data;
using Microsoft.EntityFrameworkCore;
namespace lawyer_management_system.BackgroundJobs
{
    public class RenewalBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public RenewalBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var today = DateTime.Today;
                var next3Days = today.AddDays(3);

                var cases = await context.Cases
                    .Where(c => c.RenewalDate >= today &&
                                c.RenewalDate <= next3Days &&
                                c.ReminderSent == false)
                    .ToListAsync();

                foreach (var item in cases)
                {
                   Console.WriteLine("🔁 Checking renewals...");
                    // 🔔 Simulate reminder
                    Console.WriteLine($"Reminder: {item.Title} for Client {item.ClientId}");

                    item.ReminderSent = true;
                }

                await context.SaveChangesAsync();

                // ⏳ Wait (for testing: 30 sec, later: 24 hrs)
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
