using System;
namespace BankAccount
{
    public class Transaction
    {
        public DateTime date { get; set; }
        public decimal credit { get; set; }
        public decimal debit { get; set; }
        public decimal balance { get; set; }
    }
}
