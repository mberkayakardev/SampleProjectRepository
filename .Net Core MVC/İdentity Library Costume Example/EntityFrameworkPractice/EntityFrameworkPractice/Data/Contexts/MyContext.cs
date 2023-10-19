using EntityFrameworkPractice.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.Data.Contexts
{
    public class MyContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogins, AppRoleClaims, AppUserToken>
    {
        public MyContext(DbContextOptions<MyContext> options ) : base (options)
        {
            
        }
    }
}
