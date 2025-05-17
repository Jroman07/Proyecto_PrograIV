namespace Proyecto_Final_PrograIV.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        // Clave Foránea
        public int CompanyId { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }

        // Propiedad de navegación (relación con Empresa)
        public Company? Company { get; set; }
        public List<OfferSkill>? OfferSkills { get; set; }
        public List<CandidateOffer>? CandidateOffers { get; set; }
    }
}
