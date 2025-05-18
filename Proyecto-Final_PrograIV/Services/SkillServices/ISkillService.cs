using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.SkillsServices
{
    public interface ISkillService
{
    List<Skill> GetSkills();
    Skill GetSkillById(int id);
    Skill AddSkill(Skill skill);
    Skill UpdateSkill(int id, Skill skill);
    void DeleteSkill(int id);
}

}
