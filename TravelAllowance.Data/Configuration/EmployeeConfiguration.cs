using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAllowance.Data.Models;

namespace TravelAllowance.Data.Configuration
{
        class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                builder.HasData(
                       new Employee
                       {
                           Id = 1,
                           Name = "Hein",
                           Transport = "Bike",
                           Distance = 12,
                           WorkdaysPerWeek = 5   
                       }

                  );
            }
        
    }
}
