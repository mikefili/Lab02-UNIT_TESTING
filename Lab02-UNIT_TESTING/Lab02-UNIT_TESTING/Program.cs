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
                Console.WriteLine("      Thank You for Using Virtual ATM!");
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
            AdditionalTransaction();

            return balance;
        } 

        public static decimal Withdraw()
        {
            try
            {
                Console.WriteLine("How much would you like to withdraw?");
                Console.Write("$");
                string withdrawAmt = Console.ReadLine();
                if (Convert.ToDecimal(withdrawAmt) > 0)
                {
                    if (balance - Convert.ToDecimal(withdrawAmt) > 0)
                    {
                        balance = balance - Convert.ToDecimal(withdrawAmt);
                        Console.WriteLine("Please take your cash");
                        Console.WriteLine($"Your new balance is: ${balance}");
                        Console.WriteLine();
                        AdditionalTransaction();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you have insufficient funds");
                        Console.ReadLine();
                        Withdraw();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount");
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
                string withdrawAmt = Console.ReadLine();
                if (Convert.ToDecimal(withdrawAmt) > 0)
                {
                    balance = balance + Convert.ToDecimal(withdrawAmt);
                    Console.WriteLine("Deposit successful");
                    Console.WriteLine($"Your new balance is: ${balance}");
                    Console.WriteLine();
                    AdditionalTransaction();
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount");
                    Deposit();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the amount as a number.");
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

        public static void AdditionalTransaction()
        {
            Console.WriteLine("Would you like another transaction?");
            Console.WriteLine("Y/N: ");
            string newTransactionResponse = Console.ReadLine();
            if (newTransactionResponse.ToUpper() == "Y")
            {
                Console.Clear();
                UserInterface();
            }
            else
            {
                Cancel();
            }
        }
    }
}
