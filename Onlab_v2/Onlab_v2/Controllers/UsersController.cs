using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for .Include and .ToListAsync
using Onlab.Dal;                 // Required for AppDbContext
using Onlab.Dal.Entities;        // Required for User entity
using Onlab.Transfer;            // Required for UserData (and ideally CreateUserData)
using AutoMapper;                // Required for IMapper
using System.Threading.Tasks;
using System.Collections.Generic;  // Required for IEnumerable
using System;
using AutoMapper.QueryableExtensions;
using Onlab.Bll;                     // For Exception

namespace Onlab_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(AppDbContext context, IMapper mapper, IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IList<UserData>> GetUsers()
        {
            // Access AppDbContext via the _context field
            return await context.Users
                .ProjectTo<UserData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody]CreateUserData createUserData) // Ideally, use CreateUserData DTO
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await userService.CreateUserAsync(createUserData);


            return Ok();
        }

       

        
    }
}
