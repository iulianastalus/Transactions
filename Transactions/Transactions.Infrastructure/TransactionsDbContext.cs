using Microsoft.EntityFrameworkCore;
using Transactions.Application.Interfaces;
using Transactions.Domain;

namespace Transactions.Infrastructure;

public class TransactionsDbContext :DbContext, ITransactionsDbContext
{
    public TransactionsDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Transaction> Transactions { get; set; }
    public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
}
