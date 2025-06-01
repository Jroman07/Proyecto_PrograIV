using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Skill
    {
        [JsonIgnore]
        public int SkillId{get; set;}
        public string Name {get; set;}
        public string Icon {get; set;}

        [JsonIgnore]
        public List<CandidateSkill>? CandidateSkills { get; set; }
        [JsonIgnore]
        public List<OfferSkill>? OfferSkills { get; set; }

    }
}
