using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filepath;

        public FileAccountRepository(string filepath)
        {
            _filepath = filepath;

            if (!File.Exists(_filepath))
            {
                string[] header = new string[]
                {
                    "AccountNumber,Name,Balance,Type"
                };
                File.AppendAllLines(_filepath, header);
            }
        }

        public List<Account> ListAccounts()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();

                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);

                    switch (columns[3])
                    {
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        default:
                            throw new Exception("Invalid Account Type.");
                    }

                    accounts.Add(newAccount);
                }
            }
            return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {
            var accounts = ListAccounts();

            var account = accounts.Find(x => x.AccountNumber == AccountNumber);

            return account;
        }

        public void SaveAccount(Account account)
        {
            var accounts = ListAccounts();
            var index = accounts.FindIndex(x => x.AccountNumber == account.AccountNumber);
            accounts[index] = account;
            CreateAccountFile(accounts);

        }

        public void CreateAccountFile(List<Account> accounts)
        {
            if (File.Exists(_filepath))
                File.Delete(_filepath);

            using (StreamWriter sr = new StreamWriter(_filepath))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var account in accounts)
                {
                    sr.WriteLine(CreateCsvForAccount(account));
                }
            }
        }

        private string CreateCsvForAccount(Account account)
        {
            string typer;
            switch (account.Type)
            {
                case AccountType.Basic:
                    typer = "B";
                    break;
                case AccountType.Free:
                    typer = "F";
                    break;
                case AccountType.Premium:
                    typer = "P";
                    break;
                default:
                    throw new Exception("Account Type not valid.");
            }
            return string.Format("{0},{1},{2},{3}", account.AccountNumber,
                 account.Name, account.Balance.ToString(), typer);
        }
    }








}


