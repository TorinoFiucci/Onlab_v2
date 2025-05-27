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

        Task UpdateSetlistAsync(int setlistId, SetlistData updateSetlistData);

        Task DeleteSetlistAsync(int setlistId);
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

        public async Task UpdateSetlistAsync(int setlistId, SetlistData updateSetlistData)
        {
            var setlist = await dbContext.Setlists.FindAsync(setlistId);
            if (setlist == null)
            {
                throw new KeyNotFoundException("Setlist not found");
            }
            mapper.Map(updateSetlistData, setlist);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteSetlistAsync(int setlistId)
        {
            var setlist = await dbContext.Setlists.FindAsync(setlistId);
            if (setlist == null)
            {
                throw new KeyNotFoundException("Setlist not found");
            }
            dbContext.Setlists.Remove(setlist);
            await dbContext.SaveChangesAsync();
        }
    }
}