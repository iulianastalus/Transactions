using Transactions.Domain;
using Transactions.Infrastructure.Interfaces;
using Transactions.Application.Interfaces;
using Transactions.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace Transactions.Infrastructure;

public class TransactionRepository(ITransactionsDbContext context) : ITransactionRepository
{    
    public async Task<List<Transaction>> GetAllTransactions(GetTransactionsQuery query)
    {
        List<Transaction> response;
        if (query != null)
            response = await context.Transactions.Where(p=> p.TransactionStatus == query.Status || null == query.Status)
                               .Where(p=> p.TransactionDate >= query.StartDate  || query.StartDate == default(DateTime) || query.StartDate == null)
                               .Where(p=> p.TransactionDate <= query.EndDate || query.EndDate == default(DateTime) || query.EndDate == null)
                               .Where(p => p.CurrencyCode == query.Currency || string.IsNullOrWhiteSpace(query.Currency))
                               .ToListAsync();

        else
            response = await context.Transactions.ToListAsync();

        return response;
    }

    public async Task<int> SaveTransaction(Transaction transaction)
    {        
        context.Transactions.Add(transaction);
        return await context.SaveChangesAsync();       
    }
}
