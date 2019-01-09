﻿using System;

namespace Lab02_UNIT_TESTING
{
    class Program
    {
        // declare balance
        public static decimal balance = 5000;

        // declare Main method
        static void Main(string[] args)
        {
            // welcome user and present options
            Console.WriteLine("Welcome to your Virtual ATM!");
            Console.WriteLine("****************************");
            Console.WriteLine("1) View Balance");
            Console.WriteLine("2) Withdraw");
            Console.WriteLine("3) Deposit");
            Console.WriteLine("4) Cancel");
            Console.WriteLine();
            Console.WriteLine("What type of transaction would you like?");
            Console.WriteLine("****************************************");
            Console.Write("Selection: ");
            int pick = int.Parse(Console.ReadLine());
            switch (pick)
            {
                case 1:
                    ViewBalance();
                    break;

                case 2:
                    Withdraw();
                    break;
            }
        }

        public static decimal ViewBalance()
        {
            Console.Write($"Current Balance: ${balance}");
            Console.ReadLine();
            return balance;
        } 

        public static decimal Withdraw()
        {
            Console.WriteLine("How much would you like to withdraw?");
            Console.Write("$");
            decimal withdrawAmt = Convert.ToDecimal(Console.ReadLine());
            balance = balance - withdrawAmt;
            Console.WriteLine($"Your new balance is: ${balance}");
            Console.ReadLine();
            return balance;
        }

        //public static decimal Deposit()
        //{

        //}

        //public static void Cancel()
        //{

        //}
    }
}
