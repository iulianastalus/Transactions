using Transactions.Application.Models;
using Transactions.Application.Commands;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Services;

public class FileHandlerService(ICSVService csvService, IXMLService xmlService) : IFileHandlerService
{
    public AddTransactionCommand HandleFile(string fileName, Stream fileStream)
    {
        var transactions = new List<TransactionModel>();
        switch (Path.GetExtension(fileName))
        {
            case ".csv":
                transactions = csvService.ReadCSVFile<TransactionModel>(fileStream).ToList();
                break;
            case ".xml":
                transactions = xmlService.ReadXMLFile<TransactionModel>(fileStream).ToList();
                break;
            default:
                throw new Exception();
        }
        return new AddTransactionCommand
        {
            Transactions = transactions
        };
    }
}
