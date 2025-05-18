using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services.Candidateoffer
{
    public class CandidateOfferService: ICandidateOfferService
    {
        private readonly FinalProjectDbContext _dbContext;

        public CandidateOfferService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer)
        {
            _dbContext.CandidateOffers.Add(candidateOffer);
            _dbContext.SaveChanges();

            return candidateOffer;
        }
        public void DeleteCandidateOfferById(int id)
        {
            CandidateOffer DeleteCandidateOffer = _dbContext.CandidateOffers.Find(id);

            if (DeleteCandidateOffer != null)
            {
                _dbContext.CandidateOffers.Remove(DeleteCandidateOffer);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("... not found");
            }
        }

        public List<CandidateOffer> GetAllCandidateOffer()
        {
            return _dbContext.CandidateOffers.Include(x => x.Offer).Include(x => x.Candidate).ToList();
        }

        public CandidateOffer GetCandidateOfferById(int id)
        {
            CandidateOffer candidateOffer = _dbContext.CandidateOffers.Find(id);

            if (candidateOffer == null)
            {
                throw new Exception("... not found");
            }
            return candidateOffer;
        }

        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer)
        {
            CandidateOffer updateCandidateOffer = _dbContext.CandidateOffers.Find(id);
            if (updateCandidateOffer == null)
            {
                throw new Exception("Candidate not found");
            }
            else
            {
                updateCandidateOffer.Offer = candidateOffer.Offer;
                updateCandidateOffer.Candidate = candidateOffer.Candidate;
               
                return updateCandidateOffer;
            }
        }
    }
}
