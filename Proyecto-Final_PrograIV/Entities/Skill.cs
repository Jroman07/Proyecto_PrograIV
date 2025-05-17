using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Skill
    {
        public int SkillId{get; set;}
        public int CandidateId { get; set; }
        public string Name {get; set;}

        //[JsonIgnore]
        public Candidate? Candidate { get; set; }
        [JsonIgnore]
        public IList<OfferSkill>? OfferSkills { get; set; }

    }
}
