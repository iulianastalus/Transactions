﻿namespace Transactions.Application.Models;

public class TransactionModel
{
    public string TransactionIdentificator { get; set; }
    public string Amount { get; set; }
    public string CurrencyCode { get; set; }
    public string TransactionDate { get; set; }
    public string Status { get; set; }
}
