using Transactions.Application.Interfaces;
using System.Xml.Serialization;

namespace Transactions.Application.Services;

public class XMLService : IXMLService
{
    public IEnumerable<T> ReadXMLFile<T>(Stream file)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        var result = xmlSerializer.Deserialize(file);

        return (IEnumerable<T>)result;
    }
}
