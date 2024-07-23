using MediatR;
using Transactions.Domain.Enum;

namespace Transactions.Application.Queries;

public class GetTransactionsQuery : IRequest<IEnumerable<GetTransactionsResponse>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public TransactionStatus? Status { get; set; }
    public string Currency { get; set; }
}
