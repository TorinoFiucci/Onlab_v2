using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Onlab.Dal;
using Onlab.Dal.Entities;
using Onlab.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Bll
{
    public interface IConcertService
    {
        Task<IList<ConcertData>> GetConcerts();
        Task CreateConcertAsync(CreateConcertData createConcertData);

        Task UpdateConcertAsync(int concertId, ConcertData updateConcertData);

        Task DeleteConcertAsync(int concertId);
    }

    public class ConcertService(AppDbContext dbContext, IMapper mapper) : IConcertService
    {
        public async Task<IList<ConcertData>> GetConcerts()
        {
            return await dbContext.Concerts
                .Include(c => c.Band)     
                .Include(c => c.Setlist)
                .ProjectTo<ConcertData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task CreateConcertAsync(CreateConcertData createConcertData)
        {
            var concert = mapper.Map<Concert>(createConcertData);
            dbContext.Concerts.Add(concert);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateConcertAsync(int concertId, ConcertData updateConcertData)
        {
            var concert = await dbContext.Concerts.FindAsync(concertId);
            if (concert == null)
            {
                throw new KeyNotFoundException("Concert not found");
            }
            mapper.Map(updateConcertData, concert);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteConcertAsync(int concertId)
        {
            var concert = await dbContext.Concerts.FindAsync(concertId);
            if (concert == null)
            {
                throw new KeyNotFoundException("Concert not found");
            }
            dbContext.Concerts.Remove(concert);
            await dbContext.SaveChangesAsync();
        }
    }

}
