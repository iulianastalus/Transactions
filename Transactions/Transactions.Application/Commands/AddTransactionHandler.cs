using AutoMapper;
using MediatR;
using Transactions.Domain;
using Transactions.Application.Interfaces;

namespace Transactions.Application.Commands;

public class AddTransactionHandler : IRequestHandler<AddTransactionCommand, AddTransactionResponse>
{
    ITransactionRepository _transactionRepository;
    IMapper _mapper;
    public AddTransactionHandler(ITransactionRepository transactionRepository,IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }
    public async Task<AddTransactionResponse> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionEntity = _mapper.Map<Transaction>(request);

        var transactionResponse = await _transactionRepository.SaveTransaction(transactionEntity);

        return new AddTransactionResponse
        {
            TransactionId = transactionResponse.TransactionIdentificator,
            Status = transactionResponse !=null ? Enum.ResponseStatus.Success : Enum.ResponseStatus.Error,
        };
    }
}
