using AutoMapper;
using MediatR;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Queries;

public class GetTransactionsHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<GetTransactionsResponse>>
{
    ITransactionRepository _transactionRepository;
    IMapper _mapper;
    public GetTransactionsHandler(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetTransactionsResponse>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        var response = await _transactionRepository.GetAllTransactions(request);

        return _mapper.Map<List<GetTransactionsResponse>>(response);
    }
}
