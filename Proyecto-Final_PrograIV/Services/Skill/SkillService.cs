using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services.SkillsServices
{
    public class SkillService : ISkillService
    {
        private readonly FinalProjectDbContext _dbContext;
        public SkillService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Skill> GetSkills()
        {

            return _dbContext.Skills.ToList();
        }
        public Skill AddSkill(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();

            return skill;
        }
        public Skill GetSkillById(int skillId)
        {
            return _dbContext.Skills.Find(skillId);
        }
       
        public void DeleteSkill(int id)
        {
            Skill skill = _dbContext.Skills.Find(id);
            _dbContext.Remove(skill);

            _dbContext.SaveChanges();
        }
    }
}
