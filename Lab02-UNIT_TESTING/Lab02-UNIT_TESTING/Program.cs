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
            // keep Main method running continuously until user chooses to exit
            bool whileRunning = true;
            while (whileRunning == true)
            {
                // run/call UserInterface method
                UserInterface();
            }
        }

        public static void UserInterface()
        {
            try
            {
                // welcomes user and presents options
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
                // takes in user input and stores it as variable 'pick'
                string pick = Console.ReadLine();

                switch (pick)
                {
                    // if user selects '1' display the balance and inquire about additional transaction
                    case "1":
                        ViewBalance();
                        AdditionalTransaction();
                        break;

                    // if user selects '2' intake desired withdraw amount, complete withdraw,
                    //display resulting balance and inquire about additional transaction
                    case "2":
                        Withdraw(InputToDecimal(WithdrawInput()));
                        ViewBalance();
                        AdditionalTransaction();
                        break;

                    // if user selects '3' intake desired deposit amount, complete deposit,
                    //display resulting balance and inquire about additional transaction
                    case "3":
                        Deposit(InputToDecimal(DepositInput()));
                        ViewBalance();
                        break;

                    // if user selects '4' close the app
                    case "4":
                        Cancel();
                        break;

                    // ensure user provides valid selection
                    case "":
                        Console.Clear();
                        Console.WriteLine($"You did not enter anything. Please try again.");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            // catch formatting exceptions & ensure user provides valid $ amount
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid dollar amount.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
            // catch general exceptions
            catch (Exception)
            {
                Console.WriteLine("Oops! I broke!");
            }
        }

        // method used to display current balance
        public static void ViewBalance()
        {
            Console.WriteLine();
            Console.Write($"Current Balance: ${balance}");
            Console.WriteLine();
            Console.WriteLine();
        }

        // method takes in deposit amount from user as a string & return it as the input string
        public static string DepositInput()
        {
            Console.WriteLine("How much would you like to deposit?");
            Console.Write("$");
            string input = Console.ReadLine();
            return input;
        }

        // method takes in withdraw amount from user as a string & return it as the input string
        public static string WithdrawInput()
        {
            Console.WriteLine("How much would you like to withdraw?");
            Console.Write("$");
            string input = Console.ReadLine();
            return input;
        }

        // take in deposit or withdraw amount as a string
        public static decimal InputToDecimal(string input)
        {
            try
            {
                decimal negative = 0;
                // convert input string to decimal
                decimal amount = Convert.ToDecimal(input);

                if (amount < 0)
                {
                    // confirm user provided valid amount
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("********************************************");
                    Console.WriteLine("        Please enter a valid amount.");
                    Console.WriteLine("********************************************");
                    Console.WriteLine();
                    return negative;
                }
                else
                {
                    // otherwise, return converted amount
                    return amount;
                }
            }
            // ensure user has provided an input value
            catch (ArgumentNullException)
            {
                Console.WriteLine($"You did not enter anything. Please try again.");
                Console.ReadLine();
                throw;
            }
            // ensure input value is formatted correctly
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine($"Please enter a valid dollar amount.");
                Console.WriteLine("Press ENTER to continue");
                throw;
            }
            // catch general exceptions
            catch (Exception)
            {
                throw;
            }
        }

        // method used to validate withdraw will not overdraft & complete withdraw if so
        public static decimal Withdraw(decimal amount)
        {
            try
            {
                // if withdraw will not result in overdraft, subtract withdraw amount from current balance
                if (balance - amount >= 0)
                {
                    balance = balance - amount;
                }
                // if withdraw will result in overdraft, display overdraft message
                else
                {
                    Console.WriteLine("Sorry, you have insufficient funds");
                }
            }
            // ensure input value is formatted correctly
            catch (FormatException)
            {
                Console.WriteLine("Please enter the amount as a number.");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
            return balance;
        }

        // method used to add deposit amount to current balance & return new balance
        public static decimal Deposit(decimal amount)
        {
            balance = balance + amount;
            return balance;
        }

        // thank user for using application & close app
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