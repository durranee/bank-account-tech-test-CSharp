using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class Transaction
    {
        public DateTime date { get; set; }
        public decimal credit { get; set; }
        public decimal debit { get; set; }
        public decimal balance { get; set; }

    }

    public class BankAccount
    {
        decimal balance;
        public List<Transaction> statement = new List<Transaction>();


        public BankAccount()
        {
            balance = 0;
        }

        public decimal GetBalance(){
            return balance;
        }

        public void Credit(DateTime _date, decimal _amount)
        {
            balance += _amount;
            statement.Add(new Transaction() { date = _date, credit = _amount, debit = 0, balance = balance });
        }

        public void Debit(DateTime _date, decimal _amount)
        {
            if (balance < _amount)
                throw new Exception("Insufficient Funds.");
            balance -= _amount;   
            statement.Add(new Transaction() { date = _date, credit = 0, debit = _amount, balance = balance });

        }

        public void PrintStatement()
        {
            PrintHeader();

            foreach(Transaction transaction in statement)
            {
                Console.WriteLine("{0,-12} || {1,10} || {2,-10} || {3,10}",
                                  transaction.date.ToShortDateString(),
                                  transaction.credit,
                                  transaction.debit,
                                  transaction.balance
                                 );
            }
        }


        private void PrintHeader()
        {
            Console.WriteLine("{0,-12} || {1,10} || {2,-10} || {3,10}", "Date", "Credit", "Debit", "Balance");

        }


        public void main(){
            Credit(DateTime.Now, 2015);
            Debit(DateTime.Today, 1000);
            Console.WriteLine("hello world");
            PrintStatement();

        }
    }
}
