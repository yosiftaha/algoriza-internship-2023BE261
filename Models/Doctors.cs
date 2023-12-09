namespace Vezeeta_WebsiteBE.Models
{
    public class Doctors
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Experience { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
