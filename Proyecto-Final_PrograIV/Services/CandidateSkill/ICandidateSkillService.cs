using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.CandiadateSkillService
{
    public interface ICandidateSkillService
    {
        public CandidateSkill AddCandidateSkill(CandidateSkill candidateSkill);
        public void DeleteCandidateSkill(CandidateSkill candidateSkill);
        public List<CandidateSkill> GetAllCandidateSkills();
        public CandidateSkill GetCandidateSkillById(int id);
        public CandidateSkill UpdateCandidateSkill(int id, CandidateSkill candidateSkill);
    }
}
