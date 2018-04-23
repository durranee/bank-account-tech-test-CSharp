using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace BankAccount.Tests
{
    [TestClass]
    public class BankAccountTest
    {   
        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }


        [TestMethod]
        public void BalanceShouldBeZeroAtStart()
        {
            BankAccount account = new BankAccount();
            Assert.AreEqual(0, account.GetBalance());
        }

        [TestMethod]
        public void AddGivenAmountToBalance()
        {
            BankAccount account = new BankAccount();
            account.Credit(DateTime.ParseExact("20/02/2018", "dd/MM/yyyy", null), 1000);
            Assert.AreEqual(1000, account.GetBalance());
        }

        //[TestMethod]
        //public void ExpectCreditToCreateATransactionLog()
        //{
        //    BankAccount account = new BankAccount();
        //    account.Credit(DateTime.ParseExact("20/02/2018", "dd/MM/yyyy", null), 1000);
        //    Transaction obj = new Transaction()
        //    {
        //        date = DateTime.ParseExact("20/02/2018", "dd/MM/yyyy", null),
        //        credit = 1000,
        //        debit = 0,
        //        balance = 1000
        //    };
        //    Assert.AreEqual<Transaction>(obj, account.statement[0]);
        //}


        [TestMethod]
        public void TakeAwayGivenAmountFromBalance()
        {
            BankAccount account = new BankAccount();
            account.Credit(DateTime.ParseExact("21/04/2018", "dd/MM/yyyy", null), 1000);
            account.Debit(DateTime.ParseExact("22/04/2018", "dd/MM/yyyy", null), 200);
            Assert.AreEqual(800, account.GetBalance());
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenBalanceLessThanAmountToDebit()
        {
            try
            {
                BankAccount account = new BankAccount();
                account.Credit(DateTime.ParseExact("20/04/2018", "dd/MM/yyyy", null), 100);
                account.Debit(DateTime.ParseExact("22/04/2018", "dd/MM/yyyy", null), 2000);
            }catch(Exception ex)
            {
                Assert.AreEqual("Insufficient Funds.", ex.Message);
            }
        }

        [TestMethod]
        public void ItShouldPrintTransactionHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                BankAccount account = new BankAccount();
                account.Credit(DateTime.ParseExact("20/04/2018", "dd/MM/yyyy", null), 2000);
                account.PrintStatement();
                string expected = string.Format("{0,-12} || {1,10} || {2,-10} || {3,10}\n", "Date", "Credit", "Debit", "Balance");
                expected += string.Format("{0,-12} || {1,10} || {2,-10} || {3,10}\n", "04/20/2018", "2000", "0", "2000");
                Assert.AreEqual(expected, sw.ToString());
            }
        }
    }
}
