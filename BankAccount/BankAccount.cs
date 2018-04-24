using System;
using System.Collections.Generic;

namespace BankAccount
{
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

    }
}
