using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{

    public enum TaskStatus
    {
        New,
        InProgress,
        Done
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }

        // public int BandId { get; set; } // Foreign Key
        // public Band Band { get; set; } // Navigation Property
        // public int? AssignedUserId { get; set; } // Foreign Key (nullable if optional)
        // public User AssignedUser { get; set; } // Navigation Property

    }


}
