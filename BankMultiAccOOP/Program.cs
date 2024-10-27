using BankMultiAccOOP.Entities;
using BankMultiAccOOP.Impl;
using System;
using System.Collections.Generic;

namespace BankMultiAccOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitApp();
        }

        private static void InitApp()
        {
            UserImpl userImpl = new();
            AccountImpl accountImpl = new();
            Dictionary<string, string>? accountsDataAccess = AccountsUsersDictionary(userImpl, accountImpl);
            if (accountsDataAccess != null)
            {
                Login(userImpl, accountImpl, accountsDataAccess);
            }
            else
            {
                Console.WriteLine("Problems with App");
            }
        }

        private static void Login(UserImpl userImpl, AccountImpl accountImpl, Dictionary<string, string> dataUsersAndAcc)
        {
            bool loginSuccessful = false;

            while (!loginSuccessful)
            {
                Console.WriteLine("Insert your user");
                string? user = Console.ReadLine();

                if (user != null && dataUsersAndAcc.ContainsKey(user))
                {
                    Console.WriteLine("Insert your password");
                    string? password = Console.ReadLine();
                    if (password != null && dataUsersAndAcc[user] == password)
                    {
                        loginSuccessful = true;
                        Account? account = accountImpl.FindAccountById(user);
                        ShowMenu(account, accountImpl, userImpl, dataUsersAndAcc);
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Id");
                }
            }
        }

        private static void OptionMenu()
        {
            Console.WriteLine("Choose your option: \n" +
                              "1. Money income \n" +
                              "2. Money outcome \n" +
                              "3. List all movements \n" +
                              "4. List incomes \n" +
                              "5. List outcomes \n" +
                              "6. Show current money \n" +
                              "7. Exit");
        }

        private static void ShowMenu(Account? account, AccountImpl accountImpl, UserImpl userImpl, Dictionary<string, string> dataUsersAndAcc)
        {
            if (account == null) return;

            bool stopProgram = false;
            string? stopOption;

            do
            {
                Console.Clear();
                OptionMenu();
                string? option = Console.ReadLine();

                if (int.TryParse(option, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            accountImpl.UserDepositAction(account);
                            break;
                        case 2:
                            accountImpl.UserWithdrawAction(account);
                            break;
                        case 3:
                            accountImpl.GetMovementsAccount(account);
                            break;
                        case 4:
                            accountImpl.GetIncomeMovements(account);
                            break;
                        case 5:
                            accountImpl.GetWithdrawMovements(account);
                            break;
                        case 6:
                            accountImpl.GetBalance(account);
                            break;
                        case 7:
                            Console.WriteLine("Have a good day!");
                            stopProgram = true;
                            continue;
                        default:
                            Console.WriteLine("Introduce a correct option");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Introduce a valid option");
                }

                stopProgram = CheckContinueOption();
            } while (!stopProgram);

            Login(userImpl, accountImpl, dataUsersAndAcc);
        }

        private static bool CheckContinueOption()
        {
            string? stopOption;
            do
            {
                Console.WriteLine("Do you want to continue?\n" +
                                  "Press y to continue\n" +
                                  "Press n to exit");
                stopOption = Console.ReadLine()?.Trim();

                if (stopOption?.ToLower() == "y")
                {
                    return false;
                }
                else if (stopOption?.ToLower() == "n")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect option");
                }
            } while (true);
        }

        private static Dictionary<string, string>? AccountsUsersDictionary(UserImpl userImpl, AccountImpl accountImpl)
        {
            List<User>? userList = userImpl.GetUsers();
            List<Account>? accountsList = accountImpl.GetAccounts();
            Dictionary<string, string> accountAsocUser = new();

            if (userList != null && accountsList != null)
            {
                foreach (var account in accountsList)
                {
                    foreach (var user in userList)
                    {
                        if (account.GetUserId() == user.GetUserId())
                        {
                            accountAsocUser.Add(account.GetUserId(), user.GetUserPassword());
                        }
                    }
                }
            }
            else
            {
                return null;
            }
            return accountAsocUser;
        }
    }
}
