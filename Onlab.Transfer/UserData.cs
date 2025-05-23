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
        
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? BandName { get; set; } 
        public int Id { get; set; } // Assuming you want to include Id in the DTO
    }
}