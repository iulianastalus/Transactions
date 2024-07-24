using AutoMapper;
using MediatR;
using Transactions.Domain;
using Transactions.Application.Interfaces;
using FluentValidation;
using Transactions.Application.Helpers;

namespace Transactions.Application.Commands;

public class AddTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, IValidator<AddTransactionCommand> validator) : 
    IRequestHandler<AddTransactionCommand, AddTransactionResponse>
{
    public async Task<AddTransactionResponse> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        var transactionEntities = new List<Transaction>();

        foreach (var transaction in request.Transactions) 
        {
            var transactionEntity = mapper.Map<Transaction>(transaction);
            transactionEntities.Add(transactionEntity);
        }

        var transactioncounter = 0;

        validator.ValidateAndThrow(request);

        await transactionEntities.ForEachAsync(async tEntity =>
        {
            transactioncounter += await transactionRepository.SaveTransaction(tEntity);
        });
           

        return new AddTransactionResponse
        {
            SavedTransactions = transactioncounter,
            Status = transactioncounter == transactionEntities.Count ? Enum.ResponseStatus.Success : Enum.ResponseStatus.Error,
            Message = transactioncounter == transactionEntities.Count ? "Success!" : "Error"
        };
    }
}
