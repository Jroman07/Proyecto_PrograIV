namespace Proyecto_Final_PrograIV.Entities
{
    public class Skill
    {
        public int SkillId{get; set;}
        public string Name {get; set;}
        public IList<OfferSkill>? OfferSkills { get; set; }

    }
}
