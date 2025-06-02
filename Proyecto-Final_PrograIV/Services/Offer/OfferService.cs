using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services
{
    public class OfferService : IOfferService
    {
        private readonly FinalProjectDbContext _dbContext;
        public OfferService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Offer AddOffer(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();

            return offer;
        } 

        public void DeleteOffer(int Id)
        {
            Offer? DeleteOffer = _dbContext.Offers.Find(Id);

            if (DeleteOffer != null){
                _dbContext.Offers.Remove(DeleteOffer);

                _dbContext.SaveChanges();
            }else{
                throw new Exception("Candidate not found");
            }
        } 
        public List<Offer> GetallOffers()
        {
            return _dbContext.Offers.Include(x => x.Company).ToList();
        } 

        public Offer GetOfferById(int Id)
        {
            Offer? offer = _dbContext.Offers.Find(Id);

            if (offer != null){
                return offer;
            }else{
                throw new Exception("Offer not found");
            }
        }
        public List<Offer> GetOffersByCandidate(int Id)
        {
            Candidate? candidate = _dbContext.Candidates.Find(Id);
            var candidateSkillIds = _dbContext.CandidateSkills
                .Where(cs => cs.CandidateId == Id)
                .Select(cs => cs.SkillId)
                .ToList();

            var offers = _dbContext.Offers
                .Include(o => o.OfferSkills)
                .ThenInclude(os => os.Skill)
                .Where(o => o.OfferSkills.Any(os => candidateSkillIds.Contains(os.SkillId))).Include(a=>a.Company)
                .ToList();

            return offers;
        }
        public Offer UpdateOffer(int Id, Offer offer)
        {
            Offer? UpdateOffer = _dbContext.Offers.Find(Id);

            if (UpdateOffer != null)
            {

                UpdateOffer.Job = offer.Job;
                UpdateOffer.Description = offer.Description;
                _dbContext.SaveChanges();
                return UpdateOffer;
            }
            else
            {
                throw new Exception("Offer not found");
            }
        }
    }
}