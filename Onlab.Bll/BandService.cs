using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Onlab.Dal;
using Onlab.Dal.Entities;
using Onlab.Transfer;

namespace Onlab.Bll
{
    public interface IBandService
    {
        Task<IList<BandData>> GetAllBands();
        Task CreateBandAsync(CreateBandData createBandData);
    }

    // Primary constructor
    public class BandService(AppDbContext dbContext, IMapper mapper) : IBandService
    {
        public async Task<IList<BandData>> GetAllBands()
        {
            return await dbContext.Bands
                .ProjectTo<BandData>(mapper.ConfigurationProvider)
                
                .ToListAsync();
        }

        public async Task CreateBandAsync(CreateBandData createBandData)
        {
            
            var band = mapper.Map<Band>(createBandData);

            dbContext.Bands.Add(band);
            await dbContext.SaveChangesAsync();
        }

    }
}
