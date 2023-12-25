using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Authentication.Domain.Entitys;

namespace Modules.Authentication.Infrastructure.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
