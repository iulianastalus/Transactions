using FluentValidation;

namespace Transactions.Application.Commands;

public class AddTransactionValidator :AbstractValidator<AddTransactionCommand>
{
   public AddTransactionValidator()
   {
        RuleForEach(pr => pr.Transactions).ChildRules(pr => 
        { 
            pr.RuleFor(p => p.TransactionId).NotNull().NotEmpty();
            pr.RuleFor(p => p.Amount).NotNull().NotEmpty();
            pr.RuleFor(p => p.CurrencyCode).NotNull().NotEmpty();
            pr.RuleFor(p => p.Status).NotNull().NotEmpty();
            pr.RuleFor(p => p.TransactionDate).NotNull().NotEmpty();
        });
    }
}
