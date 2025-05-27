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
        public string Description { get; set; } = string.Empty;

        public int? BandId { get; set; } // Foreign Key
        public Band? Band { get; set; } // Navigation property

        public virtual Concert? Concert { get; set; } // Reverse navigation property

    }
}
