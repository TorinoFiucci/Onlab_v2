using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        // Foreign Key to Setlist
        public int SetlistId { get; set; }
        public Setlist? Setlist { get; set; }
    }
}
