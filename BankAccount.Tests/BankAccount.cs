﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace BankAccount.Tests
{
    [TestClass]
    public class BankAccountTest
    {   
        [TestMethod]
        public void AddGivenAmountToBalance()
        {
            BankAccount account = new BankAccount();
            account.Credit(1000);
            Assert.AreEqual(1000, account.GetBalance());
        }

        [TestMethod]
        public void TakeAwayGivenAmountFromBalance()
        {
            BankAccount account = new BankAccount();
            account.Credit(1000);
            account.Debit(200);
            Assert.AreEqual(800, account.GetBalance());
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenBalanceLessThanAmountToDebit()
        {
            try
            {
                BankAccount account = new BankAccount();
                account.Credit(100);
                account.Debit(2000);
            }catch(Exception ex)
            {
                Assert.AreEqual("Insufficient Funds.", ex.Message);
            }
        }
    }
}
