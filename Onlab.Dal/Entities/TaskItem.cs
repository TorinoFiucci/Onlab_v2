using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{

    public enum TaskItemStatus
    {
        New,
        InProgress,
        Done
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskItemStatus Status { get; set; } = TaskItemStatus.New; // Default status is New

        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int UserId { get; set; } // Foreign Key
        public required User User { get; set; } // Navigation Property

        // public int BandId { get; set; } // Foreign Key
        // public Band Band { get; set; } // Navigation Property
        // public int? AssignedUserId { get; set; } // Foreign Key (nullable if optional)
        // public User AssignedUser { get; set; } // Navigation Property

    }


}
