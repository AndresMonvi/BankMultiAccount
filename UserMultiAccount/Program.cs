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
            var stopConsole = false;




            List<string> userList = new();
            List<string> passwordList = new();

            userList.Add("0001");
            userList.Add("0002");
            userList.Add("0003");
            userList.Add("0004");

            passwordList.Add("1234");
            passwordList.Add("4321");
            passwordList.Add("5678");
            passwordList.Add("8765");



            do
            {

                Console.WriteLine("Insert your user");
                user = Console.ReadLine();

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i] == user)
                    {
                        Console.WriteLine("Insert your password");
                        password = Console.ReadLine();
                        if (passwordList[i] == password)
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
                                        stopProgram = false;

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
                                        stopProgram = false;

                                        break;
                                    case 3:
                                        foreach (String element in movements) Console.WriteLine(element);
                                        stopProgram = false;

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
                                        stopProgram = false;

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
                                        stopProgram = false;

                                        break;
                                    case 6:
                                        Console.WriteLine("Your balance is " + " " + balanceAccount);
                                        stopProgram = false;

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
                                                Console.WriteLine("Incorrect option");
                                                break;
                                        }
                                    } while (stopOption?.ToLower() != "y" && stopOption?.ToLower() != "n");
                                }
                            } while (option != 7 && !stopProgram);
                            if (stopProgram)
                            {
                                Console.WriteLine("Do you want to close the cash machine?\n" +
                                                            "Press y to accept\n" +
                                                            "Press n to continue");
                                stopOption = Console.ReadLine()?.Trim();
                                switch (stopOption)
                                {
                                    case "n":
                                        stopConsole = false;
                                        break;

                                    case "y":
                                        Console.WriteLine("Your balance is " + " " + balanceAccount);
                                        Console.WriteLine("Have a good day!");
                                        stopConsole = true;
                                        break;

                                    default:
                                        Console.WriteLine("Incorrect option");
                                        break;
                                } while (stopOption?.ToLower() != "y" && stopOption?.ToLower() != "n") ;
                            }
                        }
                    }
                }
            } while (!stopConsole);
        }
    }
}
