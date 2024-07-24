using AutoMapper;
using MediatR;
using Transactions.Domain;
using Transactions.Application.Interfaces;
using FluentValidation;

namespace Transactions.Application.Commands;

public class AddTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, IValidator<AddTransactionCommand> validator) : 
    IRequestHandler<AddTransactionCommand, AddTransactionResponse>
{
    public async Task<AddTransactionResponse> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionEntities = mapper.Map<List<Transaction>>(request);
        var transactioncounter = 0;

        validator.ValidateAndThrow(request);

        foreach (var transactionEntity in transactionEntities)
            transactioncounter += await transactionRepository.SaveTransaction(transactionEntity);

        return new AddTransactionResponse
        {
            SavedTransactions = transactioncounter,
            Status = transactioncounter == transactionEntities.Count ? Enum.ResponseStatus.Success : Enum.ResponseStatus.Error,
            Message = transactioncounter == transactionEntities.Count ? "Success!" : "Error"
        };
    }
}
