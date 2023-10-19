using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppUserLogins : IdentityUserLogin<int>
    {
        public string BerkayProp3 { get; set; }

    }
}
