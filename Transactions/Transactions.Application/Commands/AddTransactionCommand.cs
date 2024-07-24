using MediatR;
using Transactions.Application.Models;

namespace Transactions.Application.Commands;

public class AddTransactionCommand : IRequest<AddTransactionResponse>
{
   public List<TransactionCommandModel> Transactions {  get; set; }
}
