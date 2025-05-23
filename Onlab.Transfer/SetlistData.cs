using Onlab.Dal.Entities; // Only if you were to include complex types, not needed for these simple DTOs

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
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? BandName { get; set; } // To display the associated band's name
    }
}