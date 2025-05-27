using System;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("venue")]
        public string Venue { get; set; } = string.Empty;
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("contact")]
        public string? Contact { get; set; }
        [JsonPropertyName("bandName")]
        public string? BandName { get; set; } // To display the associated band's name
        [JsonPropertyName("bandId")]
        public int? BandId { get; set; } // Optionally include BandId

        [JsonPropertyName("setlistId")]
        public int? SetlistId { get; set; } // Foreign Key to the Setlist
        [JsonPropertyName("setlist")]
        public SetlistData? Setlist { get; set; } // Navigation property, if needed
    }
}