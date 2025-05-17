namespace Proyecto_Final_PrograIV.Entities
{
    public class Skill
    {
        public int SkillId{get; set;}
        public int CandidateId { get; set; }
        public string Name {get; set;}

        public Candidate? Candidate { get; set; }
        public IList<OfferSkill>? OfferSkills { get; set; }

    }
}
