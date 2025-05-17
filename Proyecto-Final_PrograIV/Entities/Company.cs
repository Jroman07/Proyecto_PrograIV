namespace Proyecto_Final_PrograIV.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }

        // Relación inversa: Una empresa tiene muchas ofertas
        public List<Offer>? Offers { get; set; }
    }
}
