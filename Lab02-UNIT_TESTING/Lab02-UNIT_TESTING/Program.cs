using System;

namespace Lab02_UNIT_TESTING
{
    class Program
    {
        // declare balance
        public static decimal balance = 5000;

        // declare Main method
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************");
            Console.WriteLine("       Welcome to your Virtual ATM!");
            UserInterface();
        }

        public static void UserInterface()
        {
            string pick;
            bool whileRunning = true;
            while (whileRunning == true)
            {
                // welcome user and present options
                Console.WriteLine("********************************************");
                Console.WriteLine();
                Console.WriteLine("    1) View Balance");
                Console.WriteLine("    2) Withdraw");
                Console.WriteLine("    3) Deposit");
                Console.WriteLine("    4) Cancel");
                Console.WriteLine();
                Console.WriteLine("********************************************");
                Console.WriteLine("  What type of transaction would you like?");
                Console.WriteLine("********************************************");
                Console.WriteLine();
                Console.Write("Your Selection: ");
                pick = Console.ReadLine();

                if (pick == "")
                {
                    Console.WriteLine("Sorry, please make a valid selection.");
                    Console.WriteLine();
                }
                switch (pick)
                {
                    case "1":
                        ViewBalance();
                        break;

                    case "2":
                        whileRunning = false;
                        Withdraw();
                        break;

                    case "3":
                        whileRunning = false;
                        Deposit();
                        break;

                    case "4":
                        Cancel();
                        break;
                }
            }
        }

        public static decimal ViewBalance()
        {
            Console.WriteLine();
            Console.Write($"Current Balance: ${balance}");
            Console.WriteLine();
            Console.WriteLine();

            return balance;
        } 

        public static decimal Withdraw()
        {
            try
            {
                Console.WriteLine("How much would you like to withdraw?");
                Console.Write("$");
                decimal withdrawAmt = Convert.ToDecimal(Console.ReadLine());
                if (balance - withdrawAmt > 0)
                {
                    balance = balance - withdrawAmt;
                    Console.WriteLine("Please take your cash");
                    Console.WriteLine($"Your new balance is: ${balance}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Sorry, you have insufficient funds");
                    Console.ReadLine();
                    Withdraw();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the amount as a number.");
                Console.ReadLine();
                Withdraw();
            }
            return balance;
        }

        public static decimal Deposit()
        {
            try
            {
                Console.WriteLine("How much would you like to deposit?");
                Console.Write("$");
                decimal withdrawAmt = Convert.ToDecimal(Console.ReadLine());
                balance = balance + withdrawAmt;
                Console.WriteLine("Deposit successful");
                Console.WriteLine($"Your new balance is: ${balance}");
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the amount as a number.");
                Console.ReadLine();
                Deposit();
            }
            return balance;
        }

        public static void Cancel()
        {
            Console.WriteLine("Thank you for using your Virtual ATM!");
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
