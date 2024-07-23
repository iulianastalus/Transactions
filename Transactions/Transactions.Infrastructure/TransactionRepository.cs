using Transactions.Domain;
using Transactions.Application.Interfaces;

namespace Transactions.Infrastructure;

public class TransactionRepository : ITransactionRepository
{
    ITransactionsDbContext _context;
    public TransactionRepository(ITransactionsDbContext context)
    {
        _context = context;
    }
    public async Task<List<Transaction>> GetAllTransactions()
    {
        throw new NotImplementedException();
    }

    public async Task<Transaction> SaveTransaction(Transaction transaction)
    {
       var transactionResponse = await _context.SaveChangesAsync();
        
       if (transactionResponse > 0)
           return transaction;

        return null;
    }
}
