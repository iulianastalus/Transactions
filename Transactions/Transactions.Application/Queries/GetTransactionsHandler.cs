using AutoMapper;
using MediatR;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Queries;

public class GetTransactionsHandler(ITransactionRepository transactionRepository,IMapper mapper) : IRequestHandler<GetTransactionsQuery, IEnumerable<GetTransactionsResponse>>
{
    public async Task<IEnumerable<GetTransactionsResponse>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var response = await transactionRepository.GetAllTransactions(request);

        return mapper.Map<List<GetTransactionsResponse>>(response);
    }
}
