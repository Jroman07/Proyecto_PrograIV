using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services.Candidateoffer
{
    public interface ICandidateOfferService
    {
        public CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer);
        public void DeleteCandidateOfferById(int id);
        public List<CandidateOffer> GetAllCandidateOffer();
        public CandidateOffer GetCandidateOfferById(int id);
        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer);
    }
}
