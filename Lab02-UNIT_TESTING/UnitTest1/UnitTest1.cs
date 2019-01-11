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
            Program.balance = 5000;
            Assert.Equal(4000, Program.Withdraw(1000));
        }
    }
}
