using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Offer
    {
        [JsonIgnore]
        public int OfferId { get; set; }
        public int CompanyId { get; set; }
        public string? Job { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public Company? Company { get; set; }
        [JsonIgnore]
        public List<OfferSkill>? OfferSkills { get; set; }
        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; }
    }
}
