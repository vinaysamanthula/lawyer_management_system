using System;
using System.Collections.Generic;
namespace lawyer_management_system.Models
{
    public class LegalCase
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime  RenewalDate { get; set; }
        public bool ReminderSent { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
