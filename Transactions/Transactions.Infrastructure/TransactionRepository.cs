using Transactions.Domain;
using Transactions.Infrastructure.Interfaces;
using Transactions.Application.Interfaces;
using Transactions.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace Transactions.Infrastructure;

public class TransactionRepository : ITransactionRepository
{
    ITransactionsDbContext _context;
    public TransactionRepository(TransactionsDbContext context)
    {
        _context = context;
    }
    public async Task<List<Transaction>> GetAllTransactions(GetTransactionsQuery query)
    {
        List<Transaction> response;
        
        if (query != null)
            response = await _context.Transactions.Where(p=> p.TransactionStatus == query.Status || null == query.Status)
                               .Where(p=> p.TransactionDate >= query.StartDate  || query.StartDate == null)
                               .Where(p=> p.TransactionDate <= query.EndDate || query.EndDate == null)
                               .Where(p => p.CurrencyCode == query.Currency || string.IsNullOrWhiteSpace(query.Currency)).ToListAsync();

        else
            response = await _context.Transactions.ToListAsync();

        return response;
    }

    public async Task<int> SaveTransaction(Transaction transaction)
    {
        return await _context.SaveChangesAsync();      
    }
}
