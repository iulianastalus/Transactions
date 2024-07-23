using Transactions.Application.Commands;
using Transactions.Domain;
using AutoMapper;

namespace Transactions.Application.Mappers;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<AddTransactionCommand, Transaction>();
    }
}
