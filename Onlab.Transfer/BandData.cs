using Onlab.Dal.Entities;

namespace Onlab.Transfer
{
    public class BandData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }

    public class CreateBandData
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
    }
}
