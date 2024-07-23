using Transactions.Application.Enum;

namespace Transactions.Application.Commands;

public class AddTransactionResponse
{
    public string TransactionId { get; set; }
    public ResponseStatus Status { get; set; }
}
