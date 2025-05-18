using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{
    public class Setlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign Key to Band
        public int BandId { get; set; }
        public Band? Band { get; set; }

        // A setlist contains many task items
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
