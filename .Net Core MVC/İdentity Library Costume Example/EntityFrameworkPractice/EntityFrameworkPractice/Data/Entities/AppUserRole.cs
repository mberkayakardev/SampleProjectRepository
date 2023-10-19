using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public string BerkayProp2 { get; set; }
    }
}
