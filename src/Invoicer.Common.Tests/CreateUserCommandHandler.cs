using System;
using Invoicer.Common.Handlers;

namespace Invoicer.Common.Tests
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        public void Handle(CreateUserCommand command)
        {
            Console.WriteLine($"Create user {command.Name} {command.Surname} - handler");
           
        }
    }
}
