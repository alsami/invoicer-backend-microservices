using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(string id);
        Task SaveOrUpdateAsync(User entity);
        Task DeleteAsync(string id);
        Task<List<User>> FindAllAsync();
    }
}
