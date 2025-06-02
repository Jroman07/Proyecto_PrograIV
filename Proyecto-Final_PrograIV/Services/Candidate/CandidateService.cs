using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;
using Proyecto_Final_PrograIV.Model.Auth;

namespace Proyecto_Final_PrograIV.Services.CandidateServices
{
    public class CandidateService : ICandidateService
    {
        private readonly FinalProjectDbContext _dbContext;
        public CandidateService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            if (candidate == null)
            {
                return null;
            }
            else
            {
                Candidate? Data = _dbContext.Candidates.Where(x => x.Email == candidate.Email).FirstOrDefault();
                if (Data != null)
                {
                    return null;
                }
                else
                {
                    _dbContext.Candidates.Add(candidate);
                    _dbContext.SaveChanges();

                    return candidate;
                }
                
            }
                
        }
        public void DeleteCandidate(int Id)
        {
            Candidate DeleteCandidate = _dbContext.Candidates.Find(Id);
            if (DeleteCandidate != null)
            {
                _dbContext.Candidates.Remove(DeleteCandidate);

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }
        public List<Candidate> GetAllCandidates()
        {
            return _dbContext.Candidates.ToList();
        }

        public Candidate GetCandidateById(int Id)
        {
            Candidate? candidate = _dbContext.Candidates
                .Include(x => x.CandidateSkills)
                .FirstOrDefault(c => c.CandidateId == Id); 

            if (candidate == null)
            {
                return null;
            }
            return candidate;
        }
        public List<Offer> GetOffersByCandidate(int Id)
        {
            List<Offer> offers = _dbContext.Candidates
                .Include(c => c.CandidateOffers)
                .ThenInclude(co => co.Offer)
                .Where(c => c.CandidateId == Id)
                .SelectMany(c => c.CandidateOffers.Select(co => co.Offer))
                .ToList();

            return offers;
        }
       public List<Skill> GetSkillByCandidate(int Id)
        {
            List<Skill> skills = _dbContext.Candidates
                .Include(c=>c.CandidateSkills).
                ThenInclude(co => co.Skill)
                .Where(x=>x.CandidateId==Id)
                .SelectMany(c=>c.CandidateSkills
                .Select(co => co.Skill)).ToList();

            return skills;
        }
     
    }
}
