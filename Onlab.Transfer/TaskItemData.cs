using Onlab.Dal.Entities;
using System.Text.Json.Serialization;

namespace Onlab.Transfer
{
    public class CreateTaskItemData
    {
        public string Description { get; set; } = string.Empty;
        public DateOnly DueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int UserId { get; set; } // To associate with a user upon creation
    }

    public class TaskItemData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("dueDate")]
        public DateOnly DueDate { get; set; }
        [JsonPropertyName("user")]
        public required User User { get; set; }
        [JsonPropertyName("status")]
        public TaskItemStatus Status { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
