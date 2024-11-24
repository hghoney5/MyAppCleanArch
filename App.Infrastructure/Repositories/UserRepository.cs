using App.Core.Entities;
using App.Core.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
        
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddUserAsync(User entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }
        
        public async Task<User> UpdateUserAsync(int id, User entity)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is not null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Email = entity.Email;
                user.UpdatedAt = DateTime.UtcNow;
                
                await dbContext.SaveChangesAsync();

                return user;
            }

            return entity;
        }
        
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user is not null)
            {
                dbContext.Users.Remove(user);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }


    }
}
