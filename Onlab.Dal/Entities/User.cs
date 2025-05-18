using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlab.Dal.Entities
{
    public class User // : IdentityUser<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // e.g., Manager, Musician

        // Foreign Key to Band
        public int BandId { get; set; }
        public Band? Band { get; set; }
    }
}
