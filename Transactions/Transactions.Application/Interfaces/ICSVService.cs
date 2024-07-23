namespace Transactions.Application.Interfaces;

public interface ICSVService
{
    public IEnumerable<T> ReadCSVFile<T>(Stream file);
}
