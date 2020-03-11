using System;
using System.Reflection;
using Xunit;

namespace Invoicer.Common.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_SendCommand()
        {
            CommandBus commandBus = new CommandBus(Assembly.GetExecutingAssembly());
            commandBus.Send(new CreateUserCommand("Tom", "Jones"));
            Assert.True(true);
        }
    }
}
