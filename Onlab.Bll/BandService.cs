using Microsoft.EntityFrameworkCore;
using Onlab.Dal;
using Onlab.Dal.Entities;
using Onlab.Transfer;

namespace Onlab.Bll
{
    public interface IBandService
    {
        Task<IList<BandData>> GetAllBands();
    }

    // Primary constructor
    public class BandService(AppDbContext dbContext) : IBandService
    {
        public async Task<IList<BandData>> GetAllBands()
        {
            return await dbContext.Bands
                // .ProjectTo<BandData>(mapper.ConfigurationProvider)
                .Select( b => new BandData
                {
                    Id = b.Id,
                    Name = b.Name,
                    Genre = b.Genre
                })
                .ToListAsync();
        }
    }
}
