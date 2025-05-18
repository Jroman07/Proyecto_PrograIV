using System.Text.Json.Serialization;
namespace Proyecto_Final_PrograIV.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }

        public string Job { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]

        // Clave foránea opcional
        public int? CompanyId { get; set; }

        // Propiedad de navegación opcional
        public Company? Company { get; set; }


        public List<OfferSkill> OfferSkills { get; set; } = new();
        public List<CandidateOffer> CandidateOffers { get; set; } = new();
    }
}
