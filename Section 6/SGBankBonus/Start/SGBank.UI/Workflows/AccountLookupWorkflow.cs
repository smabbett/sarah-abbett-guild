﻿using Ninject;
using SGBank.BLL;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var _repo = kernel.Get<IAccountRepository>();

            AccountManager manager = new AccountManager(_repo);

            Console.Clear();
            Console.WriteLine("Lookup an account");
            Console.WriteLine("--------------------------");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse response = manager.LookupAccount(accountNumber);

            if(response.Success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
