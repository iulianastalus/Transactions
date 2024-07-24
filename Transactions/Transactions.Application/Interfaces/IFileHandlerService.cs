using Transactions.Application.Commands;

namespace Transactions.Application.Interfaces;

public interface IFileHandlerService
{
    AddTransactionCommand HandleFile(string fileName, Stream fileStream);
}
