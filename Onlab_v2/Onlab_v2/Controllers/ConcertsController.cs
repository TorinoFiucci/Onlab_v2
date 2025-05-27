using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Transfer;

namespace Onlab_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Inject IMapper into the controller
    public class ConcertsController(IConcertService concertService) : ControllerBase
    
        
    {
        [HttpGet]
        public async Task<IList<ConcertData>> GetConcerts()
        {
            return await concertService.GetConcerts();
        }
        [HttpPost]
        public async Task<ActionResult> CreateConcert([FromBody] CreateConcertData createConcertData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await concertService.CreateConcertAsync(createConcertData);
            return Ok();
        }

        [HttpPut("{concertId}")]
        public async Task<IActionResult> UpdateConcert(int concertId, [FromBody] ConcertData updateConcertData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await concertService.UpdateConcertAsync(concertId, updateConcertData);
            return Ok();
        }

        [HttpDelete("{concertId}")]
        public async Task<IActionResult> DeleteConcert(int concertId)
        {
            try
            {
                await concertService.DeleteConcertAsync(concertId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Concert not found");
            }
        }
    }
}
