using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAllowance.Data.Models;
using TravelAllowance.Services.Interface;

namespace TravelAllowance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var employees =  _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            var response =  _employeeService.AddEmployeeAsync(employee);
            return Ok(response);

        }
    }
}
