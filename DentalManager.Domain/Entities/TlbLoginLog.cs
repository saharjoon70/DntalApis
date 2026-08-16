using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalManager.Domain.Entities
{
    public class TlbLoginLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public bool IsSuccess { get; set; }
        public string? FailReason { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public ApplicationUser User { get; set; } = null!;
    }
}
