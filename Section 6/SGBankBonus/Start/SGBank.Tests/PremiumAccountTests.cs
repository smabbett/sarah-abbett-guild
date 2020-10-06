using NUnit.Framework;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [Test]
        [TestCase("55555", "Premium Account", 1500, AccountType.Premium, -2500, 1500, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("55555", "Premium Account", 500, AccountType.Premium, -200, 300, true)]
        [TestCase("55555", "Premium Account", 500, AccountType.Premium, -800, -310, true)]

        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, account.Balance);
            }
        }
    }
}
