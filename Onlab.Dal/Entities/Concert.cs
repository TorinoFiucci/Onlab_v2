using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{
    public class Concert
    {
        public int Id { get; set; }
        public string Venue { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Contact { get; set; } = string.Empty;



        // Foreign Key to Band
        public int? BandId { get; set; }
        public Band? Band { get; set; }

        //public int? SetlistId { get; set; } // Foreign Key to the Setlist
        
        public virtual Setlist? Setlist { get; set; }
    }
}