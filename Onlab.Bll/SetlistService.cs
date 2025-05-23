using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Onlab.Dal;
using Onlab.Dal.Entities;
using Onlab.Transfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onlab.Bll
{
    public interface ISetlistService
    {
        Task<IList<SetlistData>> GetSetlistsAsync();
        Task CreateSetlistAsync(CreateSetlistData createSetlistData);
        // Add other methods like GetSetlistByIdAsync, UpdateSetlistAsync, DeleteSetlistAsync as needed
    }

    public class SetlistService(AppDbContext dbContext, IMapper mapper) : ISetlistService
    {
        public async Task<IList<SetlistData>> GetSetlistsAsync()
        {
            return await dbContext.Setlists // Assuming AppDbContext has DbSet<Setlist> Setlists
                .ProjectTo<SetlistData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task CreateSetlistAsync(CreateSetlistData createSetlistData)
        {
            var setlistEntity = mapper.Map<Setlist>(createSetlistData);

            // Assuming AppDbContext has DbSet<Setlist> Setlists
            dbContext.Setlists.Add(setlistEntity);
            await dbContext.SaveChangesAsync();

        }
    }
}