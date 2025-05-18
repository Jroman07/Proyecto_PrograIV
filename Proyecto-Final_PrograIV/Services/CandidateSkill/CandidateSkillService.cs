using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;
using Proyecto_Final_PrograIV.Services.CandiadateSkillService;

namespace Proyecto_Final_PrograIV.Services.CandiadateSkillService
{
    public class CandidateSkillService: ICandidateSkillService
    {
   
            private readonly FinalProjectDbContext _dbContext;

            public CandidateSkillService(FinalProjectDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public CandidateSkill AddCandidateSkill(CandidateSkill candidateSkill)
            {
                _dbContext.CandidateSkills.Add(candidateSkill);
                _dbContext.SaveChanges();

                return candidateSkill;
            }
            public void DeleteCandidateSkillById(int id)
            {
                CandidateSkill DeleteCandiadateSkill = _dbContext.CandidateSkills.Find(id);

                if (DeleteCandiadateSkill != null)
                {
                    _dbContext.CandidateSkills.Remove(DeleteCandiadateSkill);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("... not found");
                }
            }

            public List<CandidateSkill> GetAllCandidateSkills()
            {
                return _dbContext.CandidateSkills.Include(x => x.Candidate).Include(x => x.Skill).ToList();
            }

            public CandidateSkill GetCandidateSkillById(int id)
            {
                CandidateSkill candidateSkill = _dbContext.CandidateSkills.Find(id);

                if (candidateSkill == null)
                {
                    throw new Exception("... not found");
                }
                return candidateSkill;
            }

            public CandidateSkill UpdateCandidateSkill(int id, CandidateSkill candidateSkill)
            {
                CandidateSkill updateCandidateSkill = _dbContext.CandidateSkills.Find(id);
                if (updateCandidateSkill == null)
                {
                    throw new Exception("... not found");
                }
                else
                {
                    updateCandidateSkill.Skill = candidateSkill.Skill;
                    updateCandidateSkill.Candidate = candidateSkill.Candidate;
                    return updateCandidateSkill;
                }
            }
    }
}
