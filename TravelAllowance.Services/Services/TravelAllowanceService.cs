using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TravelAllowance.Data.Models;
using TravelAllowance.Services.Interface;

namespace TravelAllowance.Services.Services
{
    public class TravelAllowanceService : ITravelAllowanceService
    {
        private readonly HttpClient _httpClient;

        public TravelAllowanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public decimal GetCompensationForDistance(decimal distance, string transportType)
        {
            var compensationRate =  GetCompensationRateAsync(transportType).GetAwaiter().GetResult();
            var baseCompensation = distance * compensationRate;
            if (distance >= 5 && distance <= 10 && transportType.Equals("bike"))
            {
                return baseCompensation * 2;
            }
            return baseCompensation;
        }

        public async Task<decimal> GetCompensationRateAsync(string transportType)
        {
            var response = await _httpClient.GetAsync("https://api.staging.yeshugo.com/applicant/travel_types");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var travelType = JsonConvert.DeserializeObject<IList<TravelAllowance.Data.Models.TravelType>>(content);
            var filteredResponse = travelType.Where(x => x.Name == transportType.ToLower()).FirstOrDefault();
            return filteredResponse.BaseCompensationPerKm;
        }

        public async Task<List<Data.Models.TravelAllowance>> GetTravelAllowanceAsync(List<Employee> employees)
        {
            var travelAllowances = new List<TravelAllowance.Data.Models.TravelAllowance>();
            foreach (var employee in employees)
            {
                var distance = employee.Distance * 2 * employee.WorkdaysPerWeek;
                var compensation = GetCompensationForDistance(distance, employee.Transport);
                var paymentDate = GetFirstMondayOfNextMonth();
                var travelAllowance = new TravelAllowance.Data.Models.TravelAllowance
                {
                    Employee = employee.Name,
                    Transport = employee.Transport,
                    Distance = distance,
                    Compensation = compensation,
                    PaymentDate = paymentDate
                };
                travelAllowances.Add(travelAllowance);
            }
            return travelAllowances;
        }

        private DateTime GetFirstMondayOfNextMonth()
        {
            var today = DateTime.Today;
            var firstDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            var daysUntilMonday = ((int)DayOfWeek.Monday - (int)firstDayOfNextMonth.DayOfWeek + 7) % 7;
            return firstDayOfNextMonth.AddDays(daysUntilMonday);
        }
    }
}
