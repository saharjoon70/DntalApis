using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalManager.Application.DTOs.Auth
{
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
        public string? CaptchaId { get; set; }        // ← این
        public string? CaptchaCode { get; set; }      // ← کدی که کاربر وارد میکنه
    }
}
