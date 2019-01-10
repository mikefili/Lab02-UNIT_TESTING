using System;
using Xunit;
using Lab02_UNIT_TESTING;

namespace UnitTest1
{
    public class UnitTest1
    {
        [Fact]
        public void CanViewBalance()
        {
            Program.balance = 5000;
            Assert.Equal(Program.balance, Program.ViewBalance());
        }
    }
}
