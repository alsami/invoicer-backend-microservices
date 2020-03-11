using System;
using System.Collections.Generic;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserReaderRepository
    {
        User GetUser(string userId);
        IList<User> GetUsers();
        bool UpdateUser(string userId, User userDetails);
        void DeleteUser(User user);
        int SaveUser(User user);
    }
}
