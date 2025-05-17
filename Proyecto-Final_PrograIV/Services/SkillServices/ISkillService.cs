using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.SkillsServices
{
    public interface ISkillService
    {
        public List<Skill> GetSkills();
        public Skill GetSkillById(int skillId);
        public Skill AddSkill(Skill skill);
        public Skill UpdateSkill(int id, Skill skill);
        public void DeleteSkill(int id);
    }
}
