using Microsoft.AspNetCore.Identity;

namespace PawMates.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<AdBase> Ads { get; set; } = new List<AdBase>();
    }
}
