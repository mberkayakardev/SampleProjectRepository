using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string BerkayProp6 { get; set; }
    }
}
