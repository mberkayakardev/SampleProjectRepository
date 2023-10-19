using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppRoleClaims : IdentityRoleClaim<int>
    {
        public int BerkayProp4 { get; set; }
    }
}
