using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.DataAccess;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDBContext _dbContext;
        public UserRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task DeleteAsync(string id)
        {
            var user = await FindByIdAsync(id) ?? throw new NullReferenceException($"Cannot find user with id: {id}");
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

        }

        public async Task SaveOrUpdateAsync(User entity)
        {
            var user = await FindByIdAsync(entity.Id);
            if (user == null)
            {
                await _dbContext.Users.AddAsync(entity);
            }
            else {
                if (user == entity) { throw new Exception("Nothing to update"); }
                Type type = typeof(User);
                foreach(PropertyInfo property in type.GetProperties()){
                    if (property.GetValue(user) != property.GetValue(entity)) {
                        property.SetValue(user, property.GetValue(entity));
                    }
                }

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task<List<User>> FindAllAsync() {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
