using MediatR;
using Transactions.Application.Models;

namespace Transactions.Application.Commands;

public class AddTransactionCommand : IRequest<AddTransactionResponse>
{
   public List<TransactionModel> Transactions {  get; set; }
}
