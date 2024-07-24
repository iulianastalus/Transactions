using Transactions.Domain;
using AutoMapper;
using Transactions.Application.Queries;
using Transactions.Application.Models;
using Transactions.Application.Helpers;
using System.Globalization;

using TransactionStatus = Transactions.Domain.Enum.TransactionStatus;


namespace Transactions.Application.Mappers;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<TransactionModel, Transaction>()
            .ForMember(x => x.Amount, opt => opt.MapFrom(z => decimal.Parse(z.Amount)))
            .ForMember(x => x.TransactionStatus, opt => opt.MapFrom(z => EnumHelper.ParseEnum<TransactionStatus>(z.Status)))
            .ForMember(x => x.TransactionDate, opt => opt.MapFrom(z => DateTime.ParseExact(z.TransactionDate, "dd/MM/yyyy HH:mm:ss",CultureInfo.InvariantCulture)));
        CreateMap<Transaction, GetTransactionsResponse>().ForMember(x => x.TransactionId, opt => opt.MapFrom(z=> z.TransactionIdentificator));
    }
}
