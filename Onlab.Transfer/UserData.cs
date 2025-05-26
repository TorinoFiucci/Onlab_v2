using System.Text.Json.Serialization;
namespace Onlab.Transfer
{ 
    public class CreateUserData
    {
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
       

        public int? BandId { get; set; } 
    }

    public class UserData 
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;
        [JsonPropertyName("bandName")]
        public string? BandName { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; } // Assuming you want to include Id in the DTO
    }
}