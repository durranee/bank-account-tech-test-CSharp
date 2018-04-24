using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace BankAccount.Tests
{
    [TestClass]
    public class PrinterTest
    {
        public PrinterTest()
        {
        }

        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void ItShouldPrintHeader()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Printer printer = new Printer();
                printer.PrintHeader();
                string expected = string.Format("{0,-12} || {1,10} || {2,-10} || {3,10}\n", "Date", "Credit", "Debit", "Balance");
                Assert.AreEqual(expected, sw.ToString());
            }

        }


        [TestMethod]
        public void ItShouldPrintTransactionHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                BankAccount account = new BankAccount();
                Printer printer = new Printer();
                account.Credit(DateTime.ParseExact("20/04/2018", "dd/MM/yyyy", null), 2000);
                printer.PrintBody(account.statement);
                string expected = string.Format("{0,-12} || {1,10} || {2,-10} || {3,10}\n", "04/20/2018", "2000", "0", "2000");
                Assert.AreEqual(expected, sw.ToString());
            }
        }


    }
}
