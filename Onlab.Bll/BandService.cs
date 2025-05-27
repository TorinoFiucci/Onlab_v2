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

        Task UpdateBandAsync(int bandId, BandData updateBandData);

        Task DeleteBandAsync(int bandId);
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

        public async Task UpdateBandAsync(int bandId, BandData updateBandData)
        {
            var band = await dbContext.Bands.FindAsync(bandId);
            if (band == null)
            {
                throw new KeyNotFoundException("Band not found");
            }
            mapper.Map(updateBandData, band);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBandAsync(int bandId)
        {
            var band = await dbContext.Bands.FindAsync(bandId);
            if (band == null)
            {
                throw new KeyNotFoundException("Band not found");
            }
            dbContext.Bands.Remove(band);
            await dbContext.SaveChangesAsync();
        }

    }
}
