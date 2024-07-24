namespace Transactions.Application.Models;

public class TransactionModel
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public string TransactionDate { get; set; }
    public string Status { get; set; }
}
