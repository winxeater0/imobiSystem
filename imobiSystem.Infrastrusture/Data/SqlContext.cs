using imobiSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastrusture.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
            
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Date") != null))
            {
                if(item.State == EntityState.Added)
                    item.Property("Date").CurrentValue = DateTime.Now;

                if (item.State == EntityState.Modified)
                    item.Property("Date").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}
