using Transactions.Domain.Enum;

namespace Transactions.Application.Queries;

public class GetTransactionsResponse
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionStatus Status { get; set; }
}
