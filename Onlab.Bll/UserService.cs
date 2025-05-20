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




    }
}
