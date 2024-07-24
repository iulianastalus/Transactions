using Transactions.Application.Queries;
using Transactions.Domain;
namespace Transactions.Application.Interfaces;

public interface ITransactionRepository
{
    Task<int> SaveTransaction(Transaction transaction);
    Task<List<Transaction>> GetAllTransactions(GetTransactionsQuery query);
}
