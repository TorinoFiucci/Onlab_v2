using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Transfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onlab.Controllers // Assuming your main controllers are in this namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetlistsController(ISetlistService setlistService) : ControllerBase
    {
        [HttpGet]
        public async Task<IList<SetlistData>> GetSetlists()
        {
            return await setlistService.GetSetlistsAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateSetlist([FromBody] CreateSetlistData createSetlistData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await setlistService.CreateSetlistAsync(createSetlistData);

            return Ok();
        }

        
    }
}