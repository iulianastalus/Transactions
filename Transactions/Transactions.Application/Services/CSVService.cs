using CsvHelper;
using System.Globalization;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Services;

public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSVFile<T>(Stream file)
    {
        var reader = new StreamReader(file);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records;
    }
}
