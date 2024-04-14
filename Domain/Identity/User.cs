using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
