using Microsoft.AspNetCore.Mvc;
using Onlab.Bll;
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

        //[HttpPost]
        //public async Task<ActionResult<Band>> CreateBand(Band band)
        //{
        //    _context.Bands.Add(band);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetBands), new { id = band.Id }, band);
        //}
    }
}
