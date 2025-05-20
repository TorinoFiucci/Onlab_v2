using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
using Onlab.Dal.Entities;
using Onlab.Dal;
using Onlab.Transfer;

namespace Onlab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController(IBandService bandService, AppDbContext context) : ControllerBase
    {
        

        [HttpGet]
        public async Task<IList<BandData>> GetBands()
        {
            return await bandService.GetAllBands();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBand(CreateBandData createBandData)
        {
            await bandService.CreateBandAsync(createBandData);
            return Ok();
        }
    }
}
