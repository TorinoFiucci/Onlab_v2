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
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IList<UserData>> GetUsers()
        {
            // Access AppDbContext via the _context field
            return await userService.GetUsers();
        }
        [HttpGet("byband/{bandId}")]
        public async Task<IList<UserData>> GetUsersByBandId(int bandId)
        {
            return await userService.GetUsersByBandIdAsync(bandId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserData createUserData) // Ideally, use CreateUserData DTO
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await userService.CreateUserAsync(createUserData);


            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserData updateUserData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await userService.UpdateUserAsync(userId, updateUserData);

            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                await userService.DeleteUserAsync(userId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found");
            }




        }
    }
}
