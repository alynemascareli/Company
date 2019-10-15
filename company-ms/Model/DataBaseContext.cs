using Ms.Companies.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ms.Companies.Core.Model
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyAddress> CompanyAddress { get; set; }
        public DbSet<CompanyParams> CompanyParams { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany<CompanyAddress>(f => f.CompanyAddress).WithOne().HasForeignKey(x => x.CompanyId);
            modelBuilder.Entity<Company>().HasMany<CompanyParams>(f => f.CompanyParams).WithOne().HasForeignKey(x => x.CompanyId);
            
            modelBuilder.Entity<Company>().HasIndex(u => u.CnpjCpf).IsUnique();
            modelBuilder.Entity<Company>().HasQueryFilter(p => p.DateDeleted == new DateTime(0001, 01, 01, 0, 0, 0));
            modelBuilder.Entity<Company>().HasQueryFilter(p => p.DateDeleted == new DateTime(0001, 01, 01, 0, 0, 0));
            modelBuilder.Entity<CompanyAddress>().HasQueryFilter(p => p.DateDeleted == new DateTime(0001, 01, 01, 0, 0, 0));
            modelBuilder.Entity<CompanyParams>().HasQueryFilter(p => p.DateDeleted == new DateTime(0001, 01, 01, 0, 0, 0));           

        }
    }
}
