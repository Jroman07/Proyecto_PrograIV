using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class CandidateSkill
    {
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
        public int SkillId { get; set; }
        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
