using System;
using Xunit;
using Lab02_UNIT_TESTING;

namespace UnitTest1
{
    public class UnitTest1
    {
        [Fact]
        public void CanWithdrawAmt()
        {
            decimal withdrawAmt = 1000;
            Program.balance = 5000;
            Assert.Equal(4000, Program.Withdraw(withdrawAmt));
        }

        [Fact]
        public void CantOverdraft()
        {
            decimal withdrawAmt = 6000;
            Program.balance = 5000;
            Assert.Equal(5000, Program.Withdraw(withdrawAmt));
        }

        [Fact]
        public void CanDepositAmt()
        {
            decimal depositAmt = 1000;
            Program.balance = 5000;
            Assert.Equal(6000, Program.Deposit(depositAmt));
        }

        [Fact]
        public void CannotDepositNegativeAmt()
        {
            decimal withdrawAmt = -1000;
            Program.balance = 5000;
            Assert.Equal(5000, Program.Deposit(withdrawAmt));
        }

        [Fact]
        public void CanConvertInput()
        {
            string testInput = "1000";
            Program.balance = 5000;
            Assert.Equal(1000, Program.InputToDecimal(testInput));
        }

        [Fact]
        public void CanRejectNegativeInput()
        {
            string testInput = "-1000";
            Program.balance = 5000;
            Assert.Equal(0, Program.InputToDecimal(testInput));
        }

        //[Fact]
        //public void ()
        //{
            
        //}
    }
}
