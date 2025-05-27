using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Dal.Entities;
using Onlab.Dal;
using Onlab.Transfer;

namespace Onlab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController(IBandService bandService) : ControllerBase
    {


        [HttpGet]
        public async Task<IList<BandData>> GetBands()
        {
            return await bandService.GetAllBands();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBand([FromBody] CreateBandData createBandData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await bandService.CreateBandAsync(createBandData);
            return Ok();
        }

        [HttpPut("{bandId}")]
        public async Task<IActionResult> UpdateBand(int bandId, [FromBody] BandData updateBandData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await bandService.UpdateBandAsync(bandId, updateBandData);
            return Ok();
        }

        [HttpDelete("{bandId}")]
        public async Task<IActionResult> DeleteBand(int bandId)
        {
            try
            {
                await bandService.DeleteBandAsync(bandId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Band not found");
            }
        }
    }
}
