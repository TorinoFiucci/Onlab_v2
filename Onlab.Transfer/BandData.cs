using Onlab.Dal.Entities;
using System.Text.Json.Serialization;

namespace Onlab.Transfer
{
    public class BandData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("genre")]
        public string Genre { get; set; } = string.Empty;
    }

    public class CreateBandData
    {

        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
