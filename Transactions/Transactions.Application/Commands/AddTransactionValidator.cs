using FluentValidation;

namespace Transactions.Application.Commands;

public class AddTransactionValidator :AbstractValidator<AddTransactionCommand>
{
   public AddTransactionValidator()
   {
        RuleFor(pr => pr.TransactionId).NotNull().NotEmpty();
        RuleFor(pr => pr.TransactionDate).NotNull().NotEmpty();
        RuleFor(pr => pr.Amount).NotNull().NotEmpty();
        RuleFor(pr => pr.CurrencyCode).NotNull().NotEmpty();
        RuleFor(pr => pr.Status).NotNull().NotEmpty();
    }
}
