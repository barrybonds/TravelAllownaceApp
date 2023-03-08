using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAllowance.Services.Interface
{
    public interface ICsvService
    {
        Task<Stream> WriteCsvAsync<T>(IEnumerable<T> records);
    }
}
