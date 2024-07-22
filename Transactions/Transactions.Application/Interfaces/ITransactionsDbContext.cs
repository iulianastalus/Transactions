namespace Transactions.Application.Interfaces;

public interface ITransactionsDbContext
{
    Task<int> SaveChangesAsync();
}
