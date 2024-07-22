using System.ComponentModel.DataAnnotations;
using Transactions.Domain.Enum;

namespace Transactions.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
