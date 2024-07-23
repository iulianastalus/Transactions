using Microsoft.EntityFrameworkCore;
using Transactions.Domain;

namespace Transactions.Infrastructure.Interfaces;

public interface ITransactionsDbContext
{
    Task<int> SaveChangesAsync();
    public DbSet<Transaction> Transactions { get; set; }
}
