using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Onlab.Dal;
using Onlab.Dal.Entities;
using Onlab.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Bll
{

    public interface IUserService
    {
        Task<IList<UserData>> GetUsers();
        Task CreateUserAsync(CreateUserData createUserData);

        Task UpdateUserAsync(int userId, UserData updateUserData);

        Task DeleteUserAsync(int userId);
    }


    public class UserService(AppDbContext dbContext, IMapper mapper) : IUserService
    {

        public async Task<IList<UserData>> GetUsers()
        {
            // Access AppDbContext via the _context field
            return await dbContext.Users
                .ProjectTo<UserData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task CreateUserAsync(CreateUserData createUserData)
        {
            // Map DTO to Entity using the _mapper field
            var user = mapper.Map<User>(createUserData);

            // Access AppDbContext via the _context field
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(int userId, UserData updateUserData)
        {
            // Find the existing user by Id
            var user = await dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            // Map the updated data to the existing user entity
            mapper.Map(updateUserData, user);
            // Save changes to the database
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            // Find the user by Id
            var user = await dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            // Remove the user from the database
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }


    }
}
