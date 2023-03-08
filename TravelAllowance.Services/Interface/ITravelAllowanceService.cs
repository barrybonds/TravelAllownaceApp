using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAllowance.Data.Models;

namespace TravelAllowance.Services.Interface
{
    public interface ITravelAllowanceService
    {
        Task<decimal> GetCompensationRateAsync(string transportType);
        decimal GetCompensationForDistance(decimal distance, string transportType);
        Task<List<Data.Models.TravelAllowance>> GetTravelAllowanceAsync(List<Employee> employees);
    }
}
