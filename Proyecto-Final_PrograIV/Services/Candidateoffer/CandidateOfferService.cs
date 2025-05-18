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
            _dbContext.CandidateOffer.Add(candidateOffer);
            _dbContext.SaveChanges();

            return candidateOffer;
        }
        public void DeleteCandidateOfferById(int id)
        {
            CandidateOffer DeleteCandidateOffer = _dbContext.CandidateOffer.Find(id);

            if (DeleteCandidateOffer != null)
            {
                _dbContext.CandidateOffer.Remove(DeleteCandidateOffer);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("... not found");
            }
        }

        public List<CandidateOffer> GetAllCandidateOffer()
        {
            return _dbContext.CandidateOffer.ToList();
        }

        public CandidateOffer GetCandidateOfferById(int id)
        {
            CandidateOffer candidateOffer = _dbContext.CandidateOffer.Find(id);

            if (candidateOffer == null)
            {
                throw new Exception("... not found");
            }
            return candidateOffer;
        }

        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer)
        {
            CandidateOffer updateCandidateOffer = _dbContext.CandidateOffer.Find(id);
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
