using Transactions.Domain;
namespace Transactions.Application.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> SaveTransaction(Transaction transaction);
    Task<List<Transaction>> GetAllTransactions();
}
