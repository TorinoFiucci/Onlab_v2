using Onlab.Dal.Entities;

namespace Onlab.Transfer
{
    public class CreateTaskItemData
    {
        public string Description { get; set; } = string.Empty;
        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? UserId { get; set; } // To associate with a user upon creation
    }

    public class TaskItemData
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public User? User { get; set; } 
        public Dal.Entities.TaskStatus Status { get; set; }
    }
}
