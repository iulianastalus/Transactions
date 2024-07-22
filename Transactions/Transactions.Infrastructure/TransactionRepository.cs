using System.Transactions;
using Transactions.Application.Interfaces;

namespace Transactions.Infrastructure;

public class TransactionRepository : ITransactionRepository
{
    public Task<List<Transaction>> GetAllTransactions()
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> SaveTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
