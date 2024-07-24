using Transactions.Application.Enum;

namespace Transactions.Application.Commands;

public class AddTransactionResponse
{
    public int SavedTransactions { get; set; }
    public string Message { get; set; }
    public ResponseStatus Status { get; set; }
}
