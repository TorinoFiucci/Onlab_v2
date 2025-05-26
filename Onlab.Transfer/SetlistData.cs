using Onlab.Dal.Entities; // Only if you were to include complex types, not needed for these simple DTOs
using System.Text.Json.Serialization;

namespace Onlab.Transfer
{
    public class CreateSetlistData
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? BandId { get; set; } // To associate with a band upon creation
    }

    public class SetlistData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("bandname")]
        public string? BandName { get; set; } // To display the associated band's name
    }
}