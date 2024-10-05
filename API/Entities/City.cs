using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("SouthAfricanCities", Schema = "dbo")]
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string AccentCity { get; set; }
        public string ProvinceName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int ProvinceID { get; set; }
    }
}
