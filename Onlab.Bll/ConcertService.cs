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
    }

    public class ConcertService(AppDbContext dbContext, IMapper mapper) : IConcertService
    {
        public async Task<IList<ConcertData>> GetConcerts()
        {
            return await dbContext.Concerts
                .ProjectTo<ConcertData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task CreateConcertAsync(CreateConcertData createConcertData)
        {
            var concert = mapper.Map<Concert>(createConcertData);
            dbContext.Concerts.Add(concert);
            await dbContext.SaveChangesAsync();
        }
    }

}
