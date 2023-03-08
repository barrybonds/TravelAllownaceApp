using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using TravelAllowance.Services.Interface;

namespace TravelAllowance.Services.Services
{
    public class CsvService : ICsvService
    {
        public async Task<Stream> WriteCsvAsync<T>(IEnumerable<T> records)
        {
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream))
            {
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                //csvWriter.Configuration.Delimiter = ",";
                await csvWriter.WriteRecordsAsync(records);
            }
            stream.Position = 0;
            return stream;
        }
    }
}