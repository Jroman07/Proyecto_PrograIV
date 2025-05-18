using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

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
            _dbContext.Candidates.Add(candidate);
            _dbContext.SaveChanges();

            return candidate;
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
            Candidate candidate = _dbContext.Candidates.Find(Id);
            if (candidate == null)
            {
                throw new Exception("Candidate not found");
            }
            return candidate;
        }

        public List<Candidate> GetCandidatesByName(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                return _dbContext.Candidates.ToList();
            }

            return _dbContext.Candidates
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ToList();

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

        public Candidate UpdateCandidate(int Id, Candidate candidate)
        {
            Candidate updateCandidate = _dbContext.Candidates.Find(Id);
            if (updateCandidate != null)
            {
                updateCandidate.Name = candidate.Name;
                updateCandidate.Surname1 = candidate.Surname1;
                updateCandidate.Surname2 = candidate.Surname2;
                updateCandidate.Email = candidate.Email;
                updateCandidate.Password = candidate.Password;
                _dbContext.SaveChanges();
                return updateCandidate;

            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }
    }
}
