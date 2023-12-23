using Microsoft.EntityFrameworkCore;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Infrastructure.Data
{
    public class AppealDbContext : DbContext
    {
        public AppealDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Appeal> Appeals { get; set; }
    }
}
