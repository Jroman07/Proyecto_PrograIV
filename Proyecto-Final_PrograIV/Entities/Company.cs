using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Company
    {
        [JsonIgnore]
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? WebSite { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Relación inversa: Una empresa tiene muchas ofertas
        [JsonIgnore]
        public List<Offer>? Offers { get; set; }
    }
}
