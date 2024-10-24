namespace UserMultiAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int option = 0;
            decimal money = 0;
            List<String> movements = new();
            var stopProgram = false;
            string? stopOption;
            decimal balanceAccount = 0;
            string? user, password;

            Dictionary<string, string> users = new();

            users.Add("0001", "1234");
            users.Add("0002", "4321");
            users.Add("0003", "5678");
            users.Add("0004", "8765");
            users.Add("0005", "9012");
            users.Add("0006", "2109");


            Console.WriteLine("Insert your user");
            user = Console.ReadLine();

            if (users.ContainsKey(user.Trim()))
            {
                Console.WriteLine("Insert your password");
                password = Console.ReadLine();
                if (users.TryGetValue(user, out string userPass) && userPass == password)
                {
                    Console.WriteLine("Login succesfull");

                    do
                    {
                        Console.WriteLine("Choose your option: \n" +
                        "1. Money income \n" +
                        "2. Money outcome \n" +
                        "3. List all movements \n" +
                        "4. List incomes \n" +
                        "5. List outcomes \n" +
                        "6. Show current money \n" +
                        "7. Exit");

                        option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Introduce import you want to deposit");
                                money = decimal.Parse(Console.ReadLine());
                                if (money > 0)
                                {
                                    balanceAccount += money;
                                    movements.Add("Income " + money + " Balance: " + balanceAccount);
                                    Console.WriteLine("Your balance is " + " " + balanceAccount);
                                }
                                else
                                {
                                    Console.WriteLine("You can't deposit negative money");
                                }

                                break;

                            case 2:
                                Console.WriteLine("Introduce import you want to withdraw");
                                money = decimal.Parse(Console.ReadLine() ?? "0");
                                if (balanceAccount >= money)
                                {
                                    balanceAccount = balanceAccount - money;
                                    movements.Add("Withdraw " + money + " Balance: " + balanceAccount);
                                    Console.WriteLine("Your balance is " + " " + balanceAccount);
                                }
                                else
                                {
                                    Console.WriteLine("You don't have enough money in your account");
                                    Console.WriteLine("Your balance is " + " " + balanceAccount);
                                }
                                break;
                            case 3:
                                foreach (String element in movements) Console.WriteLine(element);
                                break;

                            case 4:
                                List<string> incomeList = new List<string>();
                                foreach (var item in movements)
                                {
                                    if (item.StartsWith("Income"))
                                    {
                                        incomeList.Add(item);
                                    }
                                }
                                foreach (String element in incomeList) Console.WriteLine(element);
                                break;
                            case 5:
                                List<string> withdrawList = new List<string>();
                                foreach (var item in movements)
                                {
                                    if (item.StartsWith("Withdraw"))
                                    {
                                        withdrawList.Add(item);
                                    }
                                }
                                foreach (String element in withdrawList) Console.WriteLine(element);
                                break;
                            case 6:
                                Console.WriteLine("Your balance is " + " " + balanceAccount);
                                break;
                            case 7:
                                Console.WriteLine("Have a good day!");
                                stopProgram = true;
                                break;
                            default:
                                Console.WriteLine("Introduce a correct option");
                                break;

                        }

                        if (!stopProgram)
                        {
                            do
                            {
                                Console.WriteLine("Do you want to continue?\n" +
                                "Press y to continue\n" +
                                "Press n to exit");

                                stopOption = Console.ReadLine()?.Trim();

                                switch (stopOption)
                                {
                                    case "y":
                                        stopProgram = false;
                                        break;

                                    case "n":
                                        Console.WriteLine("Your balance is " + " " + balanceAccount);
                                        Console.WriteLine("Have a good day!");
                                        stopProgram = true;
                                        break;

                                    default:
                                        Console.WriteLine("Opcion incorrecta");
                                        break;
                                }
                            } while (stopOption?.ToLower() != "y" && stopOption?.ToLower() != "n");


                        }

                    } while (option != 7 && !stopProgram);
                }
            }

        }
    }
}




