using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppUserClaim : IdentityUserClaim<int>
    {
        public string BerkayProp5 { get; set; }
    }
}
