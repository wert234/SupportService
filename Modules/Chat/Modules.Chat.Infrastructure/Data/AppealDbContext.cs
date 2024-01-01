using Microsoft.EntityFrameworkCore;
using Modules.Chat.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Chat.Infrastructure.Data
{
    public class AppealDbContext : DbContext
    {
        public AppealDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appeal>().ToTable("Appeal")
                .HasMany(e => e.Messages)
                .WithOne(e => e.Appeal)
                .HasForeignKey(e => e.AppealId)
                .IsRequired();
        }

       public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
