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

        public Skill GetSkillById(int skillId)
        {
            var skill = _dbContext.Skills.Find(skillId);
            if (skill == null)
                throw new Exception("Habilidad no encontrada");

            return skill;
        }

        public Skill AddSkill(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
            return skill;
        }

        public Skill UpdateSkill(int id, Skill updatedSkill)
        {
            var existingSkill = _dbContext.Skills.Find(id);

            if (existingSkill == null)
                throw new Exception("Habilidad no encontrada para actualizar");

            existingSkill.Name = updatedSkill.Name;

            _dbContext.SaveChanges();
            return existingSkill;
        }

        public void DeleteSkill(int id)
        {
            var skill = _dbContext.Skills.Find(id);
            if (skill == null)
                throw new Exception("Habilidad no encontrada para eliminar");

            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();
        }
    }
}
