using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAllowance.Services.Interface;

namespace TravelAllowance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAllowanceController : ControllerBase
    {
        private readonly ITravelAllowanceService _travelAllowanceService;
        private readonly IEmployeeService _employeeService;
        private readonly ICsvService _csvService;


        public TravelAllowanceController(ITravelAllowanceService travelAllowanceService, IEmployeeService employeeService, ICsvService csvService)
        {
            _travelAllowanceService = travelAllowanceService;
            _employeeService = employeeService;
            _csvService = csvService;
        }

        [HttpGet]
        public async Task<decimal> GetCompensationRateAsync(string transportType)
        {
           var  response = await _travelAllowanceService.GetCompensationRateAsync(transportType);
            return response;
        }

        [HttpGet("travel-allowance")]
        public async Task<ActionResult> GetTravelAllowanceForEmployees()
        {
            // fetch employees from database or some other source
            var employees = await _employeeService.GetAllEmployeesAsync();

            // calculate travel allowances for employees
            var travelAllowances = await _travelAllowanceService.GetTravelAllowanceAsync(employees.ToList());

            // convert travel allowances to CSV
            var csvData = await _csvService.WriteCsvAsync(travelAllowances);

            // return CSV as file attachment
            return File(new System.Text.UTF8Encoding().GetBytes(csvData.ToString()), "text/csv", "travel-allowances.csv") ;
        }
    }
}
