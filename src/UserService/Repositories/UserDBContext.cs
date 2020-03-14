using System;
using Invoicer.Common.DataAccess;
using Microsoft.EntityFrameworkCore;
using Polly;
using UserService.Models;

namespace UserService.DataAccess
{
    public class UserDBContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);
            builder.Entity<User>().ToTable("User");
            base.OnModelCreating(builder);
        }

        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }

    }
}
