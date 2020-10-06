using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private const string _filePath = @"C:\Data\SGBank\AccountsTest.txt";
        private const string _originalData = @"C:\Data\SGBank\AccountsTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }
        [Test]
        public void CanReadDataFromFile()
        {
            FileAccountRepository repo = new FileAccountRepository(_filePath);

            List<Account> accounts = repo.ListAccounts();

            Assert.AreEqual(3, accounts.Count());

            Account check = accounts[2];

            Assert.AreEqual("33333", check.AccountNumber);
            Assert.AreEqual("Premium Customer", check.Name);
            Assert.AreEqual(1000, check.Balance);
            Assert.AreEqual(AccountType.Premium, check.Type);
        }
        [Test]
        public void CanLoadAccountfromList()
        {
            FileAccountRepository repo = new FileAccountRepository(_filePath);

            var check = repo.LoadAccount("33333");

            Assert.AreEqual("33333", check.AccountNumber);
            Assert.AreEqual("Premium Customer", check.Name);
            Assert.AreEqual(1000, check.Balance);
            Assert.AreEqual(AccountType.Premium, check.Type);
        }
    }
}
