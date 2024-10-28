using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BusHandler.Data
{
    public class FamilyUser : IdentityUser
    {
        public List<Children>? Children { get; set; } 
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
