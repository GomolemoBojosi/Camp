using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("SouthAfricanCities", Schema = "dbo")]
    public class City
    {
        public int Id { get; set; }
        public String CityName { get; set; }
        public String AccentCity { get; set; }
        public String ProvinceName { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public int ProvinceID { get; set; }
    }
}
