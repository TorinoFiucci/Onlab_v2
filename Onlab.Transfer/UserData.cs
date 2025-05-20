namespace Onlab.Transfer
{
    public class CreateUserData
    {
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        // Notice: No BandId or Band property here

        public int? BandId { get; set; } // Assuming you want to set BandId during creation
    }

    public class UserData // Optional: DTO for returning user data
    {
        
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? BandName { get; set; } // Example if you want to include band name
    }
}