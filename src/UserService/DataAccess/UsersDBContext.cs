using System;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.DataAccess
{
    public class UsersDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);
            builder.Entity<User>().ToTable("User");
            base.OnModelCreating(builder);
        }

    }
}
