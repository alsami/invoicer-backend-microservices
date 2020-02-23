using System;
using Microsoft.EntityFrameworkCore;
using Polly;
using UserService.Models;

namespace UserService.DataAccess
{
    public class UserManagementDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserManagementDBContext(DbContextOptions<UserManagementDBContext> options) : base(options)
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
