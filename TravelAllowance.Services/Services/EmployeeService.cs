using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAllowance.Data;
using TravelAllowance.Data.Models;
using TravelAllowance.Services.Interface;

namespace TravelAllowance.Services.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly TravelAllowanceDbContext _db;
        public EmployeeService(TravelAllowanceDbContext dbContext)
        {
            _db = dbContext;
        }

        public ServiceResponse<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _db.Add(employee);
                _db.SaveChanges();
                return new ServiceResponse<Employee>
                {
                    IsSuccess = true,
                    Message = "Employer added",
                    Time = DateTime.UtcNow,
                    Data = employee
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Employee>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = employee
                };

            }
        }

        public async Task <List<Employee>> GetAllEmployeesAsync()
        {
            return _db.Employees.ToList();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
