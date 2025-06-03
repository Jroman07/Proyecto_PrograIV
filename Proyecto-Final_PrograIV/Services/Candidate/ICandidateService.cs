using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.CandidateServices
{
    public interface ICandidateService
    {
        public List<Candidate> GetAllCandidates();
        public Candidate GetCandidateById(int Id);
        public List<Offer> GetOffersByCandidate(int Id);
        public List<Skill> GetSkillsByCandidate(int Id);
        public Candidate AddCandidate(Candidate candidate);
        public void DeleteCandidate(int Id);
    }
}
