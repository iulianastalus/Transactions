using MediatR;
using Transactions.Domain.Enum;

namespace Transactions.Application.Commands;

public class AddTransactionCommand : IRequest<AddTransactionResponse>
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionStatus Status { get; set; }
}
