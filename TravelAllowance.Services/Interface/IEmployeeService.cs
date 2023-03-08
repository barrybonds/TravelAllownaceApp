using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAllowance.Data.Models;

namespace TravelAllowance.Services.Interface
{
   public  interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        ServiceResponse<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        //Task<bool> DeleteEmployeeAsync(int id);
    }
}
