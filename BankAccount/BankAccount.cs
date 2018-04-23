using System;
namespace BankAccount
{
    public class BankAccount
    {
        decimal balance;

        public BankAccount()
        {
            balance = 0;
        }

        public decimal GetBalance(){
            return balance;
        }

        public void Credit(decimal amount)
        {
            balance += amount;    
        }

        public void Debit(decimal amount)
        {
            if (balance < amount)
                throw new Exception("Insufficient Funds.");
            balance -= amount;   
        }
    }
}
