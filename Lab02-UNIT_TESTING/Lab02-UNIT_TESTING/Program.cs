using System;

namespace Lab02_UNIT_TESTING
{
    class Program
    {
        // declare balance
        public decimal balance = 5000;

        // declare Main method
        static void Main(string[] args)
        {
            // welcome user and present options
            Console.WriteLine("Welcome to your Virtual ATM!");
            Console.WriteLine("What type of transaction would you like?");
            Console.WriteLine("1) View Balance");
            Console.WriteLine("2) Withdraw");
            Console.WriteLine("3) Deposit");
            Console.WriteLine("4) Cancel");
            Console.ReadLine();
        }

        public static decimal ViewBalance()
        {

        } 

        public static decimal Withdraw()
        {

        }

        public static decimal Deposit()
        {

        }

        public static void Cancel()
        {

        }
    }
}
