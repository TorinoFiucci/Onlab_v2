using System;

namespace Onlab.Transfer
{
    public class CreateConcertData
    {
        public string Venue { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Contact { get; set; }
        public int? BandId { get; set; } // To associate with a band upon creation
    }

    public class ConcertData
    {
        public int Id { get; set; }
        public string Venue { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Contact { get; set; }
        public string? BandName { get; set; } // To display the associated band's name
        public int? BandId { get; set; } // Optionally include BandId
    }
}