using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelAllowance.Data.Configuration;
using TravelAllowance.Data.Models;

namespace TravelAllowance.Data
{
    public class TravelAllowanceDbContext : IdentityDbContext
    {
        public TravelAllowanceDbContext() { }
        public TravelAllowanceDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
