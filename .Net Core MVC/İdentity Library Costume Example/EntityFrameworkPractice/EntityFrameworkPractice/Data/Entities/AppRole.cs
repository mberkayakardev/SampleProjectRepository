using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string BerkayProp7 { get; set; }
    }
}
