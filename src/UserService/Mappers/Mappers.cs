using System;
using UserService.Commands;
using UserService.Models;

namespace UserService.Mappers
{
    public static class Mappers
    {

        public static User MapToUser(this RegisterUserCommand command) => new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = command.Name,
            Address = command.Address.StreetAddress,
            PostalCode = command.Address.PostalCode,
            City = command.Address.City,
            MobileNumber = command.MobileNumber,
            EmailAddress = command.EmailAddress
        };
    }
}
