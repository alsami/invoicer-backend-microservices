using System;
using Invoicer.Common.Handlers;

namespace UserService.Commands.Handlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {

        public void Handle(RegisterUserCommand command)
        {
            Console.WriteLine($"Create user {command.Name} {command.MobileNumber} - handler");
        }
    }
}
