using System;
using Microsoft.EntityFrameworkCore;

namespace Invoicer.Common.DataAccess
{
    public abstract class DbContextBase<T> : DbContext where T : class
    {
        public DbSet<T> DataSet { get; set; }

        public DbContextBase(DbContextOptions options) : base(options) { }
        public DbContextBase() { }


    }
}
