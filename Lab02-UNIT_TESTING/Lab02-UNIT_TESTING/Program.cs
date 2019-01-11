using System;

namespace Lab02_UNIT_TESTING
{
    public class Program
    {
        // declare balance
        public static decimal balance = 5000;

        // declare Main method
        static void Main(string[] args)
        {
            bool whileRunning = true;
            while (whileRunning == true)
            {
                UserInterface();
            }
        }

        public static void UserInterface()
        {
            try
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
                string pick = Console.ReadLine();

                switch (pick)
                {
                    case "1":
                        ViewBalance();
                        AdditionalTransaction();
                        break;

                    case "2":
                        Withdraw(InputToDecimal(WithdrawInput()));
                        ViewBalance();
                        AdditionalTransaction();
                        break;

                    case "3":
                        Deposit(InputToDecimal(DepositInput()));
                        break;

                    case "4":
                        Cancel();
                        break;

                    case "":
                        Console.Clear();
                        Console.WriteLine($"You did not enter anything. Please try again.");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid dollar amount.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! I broke!");
            }
        }

        public static void ViewBalance()
        {
            Console.WriteLine();
            Console.Write($"Current Balance: ${balance}");
            Console.WriteLine();
            Console.WriteLine();
        } 

        public static string DepositInput()
        {
            Console.WriteLine("How much would you like to deposit?");
            Console.Write("$");
            string input = Console.ReadLine();
            return input;
        }

        public static string WithdrawInput()
        {
            Console.WriteLine("How much would you like to withdraw?");
            Console.Write("$");
            string input = Console.ReadLine();
            return input;
        }

        public static decimal InputToDecimal(string input)
        {
            try
            {
                decimal negative = 0;
                decimal amount = Convert.ToDecimal(input);

                if (amount < 0)
                {
                    Console.WriteLine("Sorry, you have insufficient funds");
                    return negative;
                }
                else
                {
                    return amount;
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"You did not enter anything. Please try again.");
                Console.ReadLine();
                throw;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid dollar amount.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal Withdraw(decimal amount)
        {
            try
            {
                if (balance - amount >= 0)
                {
                    balance = balance - amount;
                }
                else
                {
                    Console.WriteLine("Sorry, you have insufficient funds");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the amount as a number.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
            return balance;
        }

        public static decimal Deposit(decimal amount)
        {
            balance = balance + amount;
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
            else if (newTransactionResponse.ToUpper() == "N")
            {
                Cancel();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please provide a valid selection.");
                AdditionalTransaction();
            }
        }
    }
}
