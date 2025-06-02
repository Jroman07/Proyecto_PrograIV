using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services
{
    public interface IOfferService
    {
        public List<Offer> GetallOffers();
        public List<Offer> GetOffersByCandidate(int Id);
        public Offer GetOfferById(int Id);
        public Offer AddOffer(Offer offer);
        public Offer UpdateOffer(int Id, Offer offer);
        public void DeleteOffer(int Id);
    }
}