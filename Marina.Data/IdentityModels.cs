using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marina.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, MarinaUserLogin, MarinaUserRole, MarinaUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public bool IsSuperUser { get; set; }
    }

    public class MarinaUserRole : IdentityUserRole<int> { }
    public class MarinaUserClaim : IdentityUserClaim<int> { }
    public class MarinaUserLogin : IdentityUserLogin<int> { }

    public class MarinaRole : IdentityRole<int, MarinaUserRole>
    {
        public MarinaRole() { }
        public MarinaRole(string name) { Name = name; }
    }

    public class MarinaUserStore : UserStore<ApplicationUser, MarinaRole, int,
        MarinaUserLogin, MarinaUserRole, MarinaUserClaim>
    {
        public MarinaUserStore(MarinaContext context)
            : base(context)
        {
        }
    }

    public class MarinaRoleStore : RoleStore<MarinaRole, int, MarinaUserRole>
    {
        public MarinaRoleStore(MarinaContext context)
            : base(context)
        {
        }
    }
}
