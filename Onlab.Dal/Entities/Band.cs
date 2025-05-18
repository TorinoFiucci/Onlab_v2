using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;

        // One band has many users (band members)
        public List<User> Members { get; set; } = new();

        // One band has many concerts
        public List<Concert> Concerts { get; set; } = new();

        // One band has many setlists
        public List<Setlist> Setlists { get; set; } = new();
    }
}
