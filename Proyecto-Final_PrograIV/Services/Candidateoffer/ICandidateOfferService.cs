using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.Candidateoffer
{
    public interface ICandidateOfferService
    {
        public CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer);
        public void DeleteCandidateOffer(CandidateOffer candidateOffer);
        public List<CandidateOffer> GetAllCandidateOffer();
        public List<Offer> GetCandidateOfferById(int id);
        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer);
    }
}
