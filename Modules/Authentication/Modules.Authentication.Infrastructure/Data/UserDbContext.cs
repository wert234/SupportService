using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.Authentication.Domain.Entitys;

namespace Modules.Authentication.Infrastructure.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions options) : base(options) { }
    }
}
