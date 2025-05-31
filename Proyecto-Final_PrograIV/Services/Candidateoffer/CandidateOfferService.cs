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
            CandidateOffer postulation = _dbContext.CandidateOffers.Where(x=>x.OfferId == candidateOffer.OfferId && candidateOffer.CandidateId == candidateOffer.CandidateId).FirstOrDefault(); 

            if (postulation != null)
            {
                return null;
            }
            else{
                _dbContext.CandidateOffers.Add(candidateOffer);
                _dbContext.SaveChanges();

                return candidateOffer;
            }
           
        }

        public void DeleteCandidateOffer(CandidateOffer candidateOffer)
        {
            var candidateOffer1 = _dbContext.CandidateOffers
                .FirstOrDefault(co => co.CandidateId == candidateOffer.CandidateId && co.OfferId == candidateOffer.OfferId);

            if (candidateOffer1 != null)
            {
                _dbContext.CandidateOffers.Remove(candidateOffer1);
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

        public List<Offer> GetCandidateOfferById(int id)
        {
            var offers = _dbContext.CandidateOffers
            .Where(co => co.CandidateId == id)
            .Include(co => co.Offer)
            .ThenInclude(o => o.Company)
            .Include(co => co.Offer)
            .ThenInclude(o => o.OfferSkills)
            .ThenInclude(os => os.Skill)
            .Select(co => co.Offer)
            .ToList();

            if (offers == null)
            {
                throw new Exception("...No found");
            }

            return offers;
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
