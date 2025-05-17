using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Candidate
    {
        [JsonIgnore]
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; }
        //[JsonIgnore]
        public List<Skill>? Skills { get; set; }
    }
}
