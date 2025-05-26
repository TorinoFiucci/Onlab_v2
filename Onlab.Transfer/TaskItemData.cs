using Onlab.Dal.Entities;
using System.Text.Json.Serialization;

namespace Onlab.Transfer
{
    public class CreateTaskItemData
    {
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; } = DateTime.Now.AddDays(7); // Default due date is 7 days from now
        public int UserId { get; set; } = 0; // Default user ID, should be set to a valid user ID when creating a task item
    }

    public class TaskItemData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("dueDate")]
        public DateTime? DueDate { get; set; }
        [JsonPropertyName("user")]
        public required User User { get; set; }
        [JsonPropertyName("status")]
        public TaskItemStatus Status { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}
