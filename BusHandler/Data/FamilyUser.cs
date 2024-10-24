using Microsoft.AspNetCore.Identity;

namespace BusHandler.Data
{
    public class FamilyUser : IdentityUser
    {
        public int FamilyUserId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
