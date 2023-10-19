using Microsoft.AspNetCore.Identity;

namespace EntityFrameworkPractice.Data.Entities
{
    public class AppUserToken : IdentityUserToken<int>
    {
        public string BerkayProp1 { get; set; }
    }
}
