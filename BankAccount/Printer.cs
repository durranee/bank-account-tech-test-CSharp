using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class Printer
    {
        public Printer()
        {
        }

        public void PrintBody(List<Transaction> statement)
        {
            foreach (Transaction transaction in statement)
            {
                Console.WriteLine("{0,-12} || {1,10} || {2,-10} || {3,10}",
                                  transaction.date.ToShortDateString(),
                                  transaction.credit,
                                  transaction.debit,
                                  transaction.balance
                                 );
            }
        }

        public void PrintHeader()
        {
            Console.WriteLine("{0,-12} || {1,10} || {2,-10} || {3,10}", 
                              "Date", "Credit", "Debit", "Balance");
        }

    }
}
