using Transactions.Application.Commands;
using Transactions.Domain;
using AutoMapper;
using Transactions.Application.Queries;

namespace Transactions.Application.Mappers;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<AddTransactionCommand, Transaction>();
        CreateMap<Transaction, GetTransactionsResponse>();
    }
}
