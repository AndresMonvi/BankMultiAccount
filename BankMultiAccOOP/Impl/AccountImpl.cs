using BankMultiAccOOP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankMultiAccOOP.Impl
{
    internal class AccountImpl
    {

        List<Account> Accounts = new();

        public AccountImpl()
        {
            CreateAccounts();
        }

        internal void CreateAccounts()
        {

            Account Account1 = new("12", "123456", 134.50, new List<Movement>());
            Account Account2 = new("7", "7890", 77.65, new List<Movement>());
            Account Account3 = new("2", "4K4K4K", 986.77, new List<Movement>());

            AddAccountToList(Account1);
            AddAccountToList(Account2);
            AddAccountToList(Account3);

        }

        internal List<Account>? GetAccounts()
        {
            if(Accounts == null)
            {
                return null;
            }
            return Accounts;
        }

        internal void GetBalance(Account Account)
        {
            Console.WriteLine($"Balance: {Account.GetBalance()}");

        }

        private void AddAccountToList(Account Account)
        {
            if (Account == null)
            {
                Console.WriteLine("There's no Account");
            }
            else
            {
                Accounts.Add(Account);
            }
        }

        public Account? FindAccountById(string id)
        {
            foreach (var account in Accounts)
            {
                if (account.GetUserId() == id)
                {
                    return account;
                }
            }
            Console.WriteLine("Account not found");
            return null;
        }


        private void AddMoneyToAccount(Account account, double money)
        {
            double balance = account.GetBalance();
            balance += money;
            account.SetBalance(balance);
        }

        private void WithdrawMoneyFromAccount(Account account, double money)
        {
            double balance = account.GetBalance();
            if (balance == 0 || balance < money)
            {
                Console.WriteLine("You don't have enough money");
            }
            else
            {
                balance -= money;
                account.SetBalance(balance);
            }
        }

        private void AddMovementToAccount(Account Account, string Type, double Quantity)
        {
            Movement Movement = new Movement(Type, Quantity);
            Account.GetMovementList().Add(Movement);
        }

        internal void UserDepositAction(Account Account)
        {
            Console.WriteLine("Introduce import you want to deposit");
            string? input = Console.ReadLine();
            double money;
            bool correctFormat = double.TryParse(input?.Trim().Replace(",", "."), out money);

            if (correctFormat)
            {
                AddMoneyToAccount(Account, money);
                AddMovementToAccount(Account, "deposit", money);
                Console.WriteLine("Action succesfull");
            }
            else
            {
                Console.WriteLine("Problems with the input introduced");
            }
        }

        internal void UserWithdrawAction(Account account)
        {
            Console.WriteLine("Introduce import you want to withdraw");
            string? input = Console.ReadLine();
            double money;
            bool correctFormat = double.TryParse(input?.Trim().Replace(",", "."), out money);

            if (correctFormat)
            {
                double balance = account.GetBalance();
                if (balance == 0 || balance < money)
                {
                    Console.WriteLine("You don't have enough money");
                }
                else
                {
                    WithdrawMoneyFromAccount(account, money);
                    AddMovementToAccount(account, "withdraw", money);
                    Console.WriteLine("Action succesfull");
                }
            }
            else
            {
                Console.WriteLine("Problems with the input introduced");
            }
        }

        internal void GetMovementsAccountByType(string Type, Account Account)
        {

            if (Account.GetMovementList() == null)
            {
                Console.WriteLine("No movements found.");
            }

            bool found = false;
            foreach (var mov in Account.GetMovementList())
            {
                if (mov.GetTypeOfMovement() == Type)
                {
                    Console.WriteLine($"Quantity: {mov.GetMoneyMovement()} Balance: {Account.GetBalance()}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No movements found for type: {Type}");
            }
        }

        internal void GetMovementsAccount(Account Account)
        {
            if (Account.GetMovementList == null)
            {
                Console.WriteLine("No movements");
            }
            else
            {
                foreach (var Mov in Account.GetMovementList())
                {
                    Console.WriteLine($"{Mov.GetTypeOfMovement()} : {Mov.GetMoneyMovement()} | Balance {Account.GetBalance()}");
                }
            }
        }

        internal void GetIncomeMovements(Account Account)
        {

            if (Account.GetMovementList == null)
            {
                Console.WriteLine("No movements");
            }
            else
            {
                foreach (var Mov in Account.GetMovementList())
                {
                    if (Mov.GetTypeOfMovement() == "deposit")
                    {
                        Console.WriteLine($"{Mov.GetDepositType()} : {Mov.GetMoneyMovement()} | Balance {Account.GetBalance()}");
                    }
                }
            }
        }

        internal void GetWithdrawMovements(Account Account)
        {

            if (Account.GetMovementList == null)
            {
                Console.WriteLine("No movements");
            }
            else
            {
                foreach (var Mov in Account.GetMovementList())
                {
                    if (Mov.GetTypeOfMovement() == "withdraw")
                    {
                        Console.WriteLine($"{Mov.GetWithdrawType()} : {Mov.GetMoneyMovement()} | Balance {Account.GetBalance()}");
                    }
                }
            }
        }

    }
}
