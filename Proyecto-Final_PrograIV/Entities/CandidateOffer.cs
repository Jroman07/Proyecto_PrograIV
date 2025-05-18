using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class CandidateOffer
    {
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
        public int OfferId { get; set; }
        [JsonIgnore]
        public Offer? Offer { get; set; }

    }
}
