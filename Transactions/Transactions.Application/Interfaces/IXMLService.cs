namespace Transactions.Application.Interfaces;

public interface IXMLService
{
    public IEnumerable<T> ReadXMLFile<T>(Stream file);
}
