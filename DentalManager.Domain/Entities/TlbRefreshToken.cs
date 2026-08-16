using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalManager.Domain.Entities
{
    public class TlbRefreshToken
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; } = false;
        public string? ReplacedByToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ApplicationUser User { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
