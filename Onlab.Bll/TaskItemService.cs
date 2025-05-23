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
    public interface ITaskItemService
    {
        Task<IList<TaskItemData>> GetTaskItems();
        Task CreateTaskItemAsync(CreateTaskItemData createTaskItemData);

        Task UpdateTaskItemStatus(int taskItemId, Dal.Entities.TaskStatus status);
    }

    public class TaskItemService(AppDbContext dbContext, IMapper mapper) : ITaskItemService
    {
        public async Task<IList<TaskItemData>> GetTaskItems()
        {
            return await dbContext.Tasks
                .ProjectTo<TaskItemData>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task CreateTaskItemAsync(CreateTaskItemData createTaskItemData)
        {
            var taskItemEntity = mapper.Map<TaskItem>(createTaskItemData);
            dbContext.Tasks.Add(taskItemEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateTaskItemStatus(int taskItemId, Dal.Entities.TaskStatus status)
        {
            var taskItem = await dbContext.Tasks.FindAsync(taskItemId);
            if (taskItem != null)
            {
                taskItem.Status = status;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
