using Invoicer.Common;
using UserService.Models;

namespace UserService.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public readonly string Name;
        public readonly Address Address;
        public string MobileNumber;
        public string EmailAddress;

        public RegisterUserCommand(string name, string mobileNumber, string emailAddress, Address address)
        {
            Name = name;
            Address = address;
            MobileNumber = mobileNumber;
            EmailAddress = emailAddress;
        }
    }
}
