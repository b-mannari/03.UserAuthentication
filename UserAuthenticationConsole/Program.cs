using System;
using UserAuthentication;
using UserAuthentication.ClassObjects;
using UserAuthenticationService;

namespace UserAuthenticationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            UserAccount userAccount = new UserAccount();
            ConsoleInputs inputs = new ConsoleInputs();

        Start:
            inputs.StartOperation();

            if (!Validation.IsValidOption(inputs.OptionType))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please choose numbers between 0 and 3"); goto Start;
            }
            Console.WriteLine("You have choosen: " + inputs.OptionType);

            string username = ""; string password = ""; string message;
            if (Convert.ToInt32(inputs.OptionType) == 1 || Convert.ToInt32(inputs.OptionType) == 2)
            {
                Console.WriteLine("Please enter your Username");
                username = Console.ReadLine();
                Console.WriteLine("Please enter your Password");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("The password should Minimum length of password is 6, at least 1 alphabet and at least 1 integer");
                Console.ForegroundColor = ConsoleColor.White; 
                password = Console.ReadLine();
            }

            switch (Convert.ToInt32(inputs.OptionType))
            {
                case 0:
                    Console.Clear(); goto Start;
                case 1:
                    CreateUser createUser = new CreateUser();
                    userAccount.Username = username; userAccount.Password = password;
                    message = createUser.AddNewUser(userAccount.Username, userAccount.Password);
                    if (message.Contains("Unable"))
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    else
                    { Console.ForegroundColor = ConsoleColor.Green; }

                    Console.WriteLine(message); goto Start;
                case 2:
                    LoginUser loginUser = new LoginUser();
                    userAccount.Username = username; userAccount.Password = password;
                    message = loginUser.Login(userAccount.Username, userAccount.Password, userAccount);
                    if (message.Contains("failure"))
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    else
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    Console.WriteLine(message); goto Start;
                case 3:
                    message = "Exiting...";
                    Console.WriteLine(message);
                    break;
            }
        }
    }
}