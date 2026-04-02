
using System;
using System.Collections.Generic;
namespace lawyer_management_system.Models
{
    public class Client
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }

            public List<LegalCase>? Cases { get; set; }
        
    }
}
