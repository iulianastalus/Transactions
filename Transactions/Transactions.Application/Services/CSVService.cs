using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Services;

public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSVFile<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            HasHeaderRecord = true,
            TrimOptions = TrimOptions.Trim,
            MissingFieldFound = null
        };
        var csv = new CsvReader(reader, conf);

        var records = csv.GetRecords<T>();
        return records;
    }
}
