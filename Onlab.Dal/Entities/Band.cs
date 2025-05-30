﻿using System;
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

        public ICollection<User> Users { get; set; } = new List<User>();  // Navigation property

        // One band has many concerts
        //public List<Concert> Concerts { get; set; } = new();

        // One band has many setlists
        //public List<Setlist> Setlists { get; set; } = new();
    }
}
